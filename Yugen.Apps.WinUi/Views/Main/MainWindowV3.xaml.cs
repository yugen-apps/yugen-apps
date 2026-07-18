using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

namespace Yugen.Apps.WinUi.Views.Main;

public sealed partial class MainWindowV3 : Window
{
    public MainWindowV3()
    {
        InitializeComponent();

        ExtendsContentIntoTitleBar = true;
        SetTitleBar(AppTitleBar);

        AppWindow.SetIcon("Assets/Store/AppIcon.ico");

        ViewModel = App.Current.Services.GetService<MainViewModel>();
    }

    public MainViewModel ViewModel { get; }

    public string WindowTitle { get; } = "Yugen Apps";
}