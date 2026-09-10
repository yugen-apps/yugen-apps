using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.Web.WebView2.Core;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.System;
using Yugen.Apps.WinUi.Views.Xaml;

namespace Yugen.Apps.WinUi.Views.Main;

public partial class WebPreviewViewModel : ObservableObject
{
    private const string KeydownBridgeJs = @"
        (function(){
            try {
                if (window.__hostKeydownBridgeInstalled) return;
                window.__hostKeydownBridgeInstalled = true;
                document.addEventListener('keydown', function(event){
                    try { window.chrome?.webview?.postMessage({ type: 'keydown', keyCode: event.keyCode }); } catch(_) {}
                }, true);
            } catch(_) {}
        })();";

    private const int WebView2EscapeKeyCode = 27;
    private static readonly SvgImageSource DefaultFavicon = new SvgImageSource(new Uri("ms-appx:///Assets/Img/Icons/Website_Light.svg"));
    private static bool _loadWebView2UI = false;
    private readonly string BlankUrl = "about:blank";
    private ulong? _currentNavigationId;
    private WebView2 _webView2;

    public WebPreviewViewModel()
    {
    }

    [ObservableProperty]
    public partial bool ErrorLoadingWebPreview { get; set; }

    [ObservableProperty]
    public partial ImageSource FaviconImage { get; set; }

    public bool IsBlankPage => WebPreviewSource?.ToString() == BlankUrl;

    [ObservableProperty]
    public partial bool IsWebPreviewLoading { get; set; }

    [ObservableProperty]
    public partial bool IsWebPreviewOpened { get; set; }

    public bool LoadWebView2UI
    {
        get => _loadWebView2UI;
        set => SetProperty(ref _loadWebView2UI, value);
    }

    [ObservableProperty]
    public partial string Url { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsBlankPage))]
    public partial Uri WebPreviewSource { get; set; } = null;

    [ObservableProperty]
    public partial string WebTitle { get; set; }

    public void Open(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return;
        }

        Url = url;

        NavigateTo(url);
    }

    public void Unload()
    {
        _webView2 = null;
    }

    public async void WebView2Loaded(object sender, RoutedEventArgs __)
    {
        var webView = (WebView2)sender;
        if (webView == null)
        {
            return;
        }

        _webView2 = webView;
        var core = _webView2.CoreWebView2;
        if (core == null)
        {
            await _webView2.EnsureCoreWebView2Async();
            core = _webView2.CoreWebView2;
            if (core != null)
            {
                core.Settings.AreDevToolsEnabled = false;
                core.Settings.AreBrowserAcceleratorKeysEnabled = false;
                core.Profile.IsGeneralAutofillEnabled = true;
                core.Profile.IsPasswordAutosaveEnabled = true;
                await core.AddScriptToExecuteOnDocumentCreatedAsync(KeydownBridgeJs);
            }
        }
        if (core == null)
        {
            return;
        }

        core.Profile.PreferredColorScheme = App.Current.RequestedTheme switch
        {
            ApplicationTheme.Dark => CoreWebView2PreferredColorScheme.Dark,
            ApplicationTheme.Light => CoreWebView2PreferredColorScheme.Light,
            _ => CoreWebView2PreferredColorScheme.Auto
        };

        core.WebMessageReceived -= WebPreviewViewModel_WebMessageReceived;
        core.WebMessageReceived += WebPreviewViewModel_WebMessageReceived;
        core.DOMContentLoaded -= CoreWebView2DOMContentLoaded;
        core.DOMContentLoaded += CoreWebView2DOMContentLoaded;
        core.FaviconChanged -= CoreWebView2_FaviconChanged;
        core.FaviconChanged += CoreWebView2_FaviconChanged;

        FaviconImage = DefaultFavicon;
    }

    public void WebView2NavigationCompleted(WebView2 _, CoreWebView2NavigationCompletedEventArgs args)
    {
        if (args.NavigationId == _currentNavigationId)
        {
            ErrorLoadingWebPreview = args.WebErrorStatus != CoreWebView2WebErrorStatus.Unknown;
        }
        IsWebPreviewLoading = false;
        var coreTitle = _webView2?.CoreWebView2?.DocumentTitle;
        WebTitle = string.IsNullOrWhiteSpace(coreTitle) || coreTitle == "about:blank" ? "Loading..." : coreTitle;
    }

    public void WebView2NavigationStarting(WebView2 _, CoreWebView2NavigationStartingEventArgs args)
    {
        IsWebPreviewLoading = true;
        _currentNavigationId = args.NavigationId;
    }

    private static async void CoreWebView2DOMContentLoaded(CoreWebView2 sender, CoreWebView2DOMContentLoadedEventArgs args)
    {
        try
        {
            await sender.ExecuteScriptAsync(KeydownBridgeJs);
        }
        catch
        {
            /* ignore */
        }
    }

    [RelayCommand]
    private void CloseWebPreview()
        => NavigateTo(null);

    private async void CoreWebView2_FaviconChanged(CoreWebView2 sender, object args)
    {
        if (string.IsNullOrEmpty(sender.FaviconUri))
        {
            // site has no favicon
            FaviconImage = DefaultFavicon;
            return;
        }

        try
        {
            using var stream = await sender.GetFaviconAsync(
                CoreWebView2FaviconImageFormat.Png);
            var bitmap = new BitmapImage();
            await bitmap.SetSourceAsync(stream);
            FaviconImage = bitmap;
        }
        catch
        {
            FaviconImage = null;
        }
    }

    [RelayCommand]
    private async Task LaunchExternalAsync()
    {
        try
        {
            await Launcher.LaunchUriAsync(new Uri(Url));
        }
        catch
        {
        }
    }

    [RelayCommand]
    private async Task CopyAsync()
    {
        var package = new DataPackage();
        package.SetText(Url);
        Clipboard.SetContent(package);
    }

    private void NavigateTo(string url)
    {
        if (!LoadWebView2UI)
        {
            LoadWebView2UI = true;
        }
        ErrorLoadingWebPreview = false;

        if (string.IsNullOrWhiteSpace(url))
        {
            WebPreviewSource = new Uri(BlankUrl, UriKind.RelativeOrAbsolute);
            WebPreviewSource = null;
            IsWebPreviewOpened = false;
            return;
        }
        try
        {
            IsWebPreviewOpened = true;
            WebPreviewSource = new Uri(url, UriKind.RelativeOrAbsolute);
        }
        catch (Exception)
        {
            ErrorLoadingWebPreview = true;
        }
    }

    [RelayCommand]
    private void Reload()
    {
        if (_webView2?.CoreWebView2 != null)
        {
            _webView2.CoreWebView2.Reload();
        }
    }

    private void WebPreviewViewModel_WebMessageReceived(CoreWebView2 sender, CoreWebView2WebMessageReceivedEventArgs args)
    {
        try
        {
            var message = JsonSerializer.Deserialize<WebMessage>(args.WebMessageAsJson);

            if (message != null && message.Type == "keydown")
            {
                if (message.KeyCode == WebView2EscapeKeyCode)
                {
                    CloseWebPreview();
                }
            }
        }
        catch
        {
        }
    }

    private sealed record WebMessage(
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("keyCode")] int? KeyCode
    );
}