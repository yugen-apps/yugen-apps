using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

namespace Yugen.Apps.WinUi.Views.Main;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        ExtendsContentIntoTitleBar = true;
        SetTitleBar(AppTitleBar);

        AppWindow.SetIcon("Assets/Store/AppIcon.ico");

        ViewModel = App.Current.Services.GetService<MainViewModel>();
    }

    public MainViewModel ViewModel { get; }

    #region WebPreview dimension and position management

    private void PopupDimensionsReference_SizeChanged(object _, SizeChangedEventArgs __)
        => PopupDimensionsReferenceSizeChanged();

    private void PopupDimensionsReferenceSizeChanged()
    {
        if (ViewModel?.WebPreview.LoadWebView2UI != true)
        {
            return;
        }

        var containerWidth = PopupDimensionsReference.ActualWidth;
        var containerHeight = PopupDimensionsReference.ActualHeight;

        WebPreviewPopupContent.Width = containerWidth;
        WebPreviewPopupContent.Height = containerHeight;

        WebPreviewPopup.HorizontalOffset = 0;
        WebPreviewPopup.VerticalOffset = 0;
    }

    private void WebPreviewPopup_Closed(object _, object __)
            => ViewModel?.WebPreview.CloseWebPreviewCommand?.Execute(default);

    private void WebPreviewPopup_KeyDown(object _, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Escape)
        {
            ViewModel?.WebPreview.CloseWebPreviewCommand?.Execute(default);
            e.Handled = true;
        }
    }

    private void WebPreviewPopup_Opened(object sender, object __)
    {
        PopupDimensionsReferenceSizeChanged();
        WebPreviewPopupContent.Focus(FocusState.Programmatic);
    }

    #endregion WebPreview dimension and position management
}