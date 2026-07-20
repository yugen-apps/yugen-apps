using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using System;
using System.Numerics;

namespace Yugen.Apps.WinUi.Views.Main;

public sealed partial class ProjectTileUserControl : UserControl
{
    public static readonly DependencyProperty ProjectProperty =
        DependencyProperty.Register(nameof(Project), typeof(ProjectObservableObject), typeof(ProjectTileUserControl),
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
}