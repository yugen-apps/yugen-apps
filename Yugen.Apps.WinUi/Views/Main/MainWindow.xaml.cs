using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Web.WebView2.Core;
using System;

namespace Yugen.Apps.WinUi;

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

	//private void WebView2_CoreWebView2Initialized(WebView2 sender, CoreWebView2InitializedEventArgs args)
	//{
	//	WebView2.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
	//}

	//private void CoreWebView2_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs args)
	//{
	//	args.Handled = true;
	//	// No need to wait for the launcher to finish sending the URI to the browser
	//	// before we allow the WebView2 in our app to continue.
	//	_ = Windows.System.Launcher.LaunchUriAsync(new Uri(args.Uri));
	//	// LaunchUriAsync is the WinRT API for launching a URI.
	//	// Another option not involving WinRT might be System.Diagnostics.Process.Start(args.Uri);
	//}
}
