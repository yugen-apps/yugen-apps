using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Windows.Input;

namespace Yugen.Apps.WinUi.Views.Main;

public sealed partial class ProjectTileUserControl : UserControl
{
    public static readonly DependencyProperty ProjectProperty =
        DependencyProperty.Register(
            nameof(Project), 
            typeof(ProjectObservableObject), 
            typeof(ProjectTileUserControl),
            new PropertyMetadata(default));
    
    public static readonly DependencyProperty LaunchCommandProperty =
        DependencyProperty.Register(
            nameof(LaunchCommand),
            typeof(ICommand),
            typeof(ProjectTileUserControl),
            new PropertyMetadata(default(ICommand)));

    public static DependencyProperty LaunchCommandParameterProperty =
        DependencyProperty.Register(
            nameof(LaunchCommandParameter),
            typeof(object),
            typeof(ProjectTileUserControl),
            new PropertyMetadata(default));

    public ProjectTileUserControl()
    {
        InitializeComponent();
    }

    public ProjectObservableObject Project
    {
        get => (ProjectObservableObject)GetValue(ProjectProperty);
        set => SetValue(ProjectProperty, value);
    }

    public ICommand LaunchCommand
    {
        get => (ICommand)GetValue(LaunchCommandProperty);
        set => SetValue(LaunchCommandProperty, value);
    }

    public object LaunchCommandParameter
    {
        get { return GetValue(LaunchCommandParameterProperty); }
        set { SetValue(LaunchCommandParameterProperty, value); }
    }
}