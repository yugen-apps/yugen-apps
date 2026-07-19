using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;
using Yugen.Apps.Shared.ProjectsService;

namespace Yugen.Apps.WinUi;

public partial class App : Application
{
    private Window _window;

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        Services = ConfigureServices();

        InitializeComponent();
    }

    public new static App Current => (App)Application.Current;

    public IServiceProvider Services { get; }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        _window = new MainWindow();
        _window.Activate();
    }

    private static IServiceProvider ConfigureServices() => new ServiceCollection()
            .AddTransient<MainViewModel>()
            .AddSingleton<IProjectsService, ProjectsService>()
            .BuildServiceProvider();
}