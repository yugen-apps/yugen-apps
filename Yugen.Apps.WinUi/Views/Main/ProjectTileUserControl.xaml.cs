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

    private static Compositor Comp => CompositionTarget.GetCompositorForCurrentThread();

    private static void AnimateOpacity(UIElement el, float to, int ms = 200)
    {
        var fade = Comp.CreateScalarKeyFrameAnimation();
        fade.Target = nameof(UIElement.Opacity);
        fade.InsertKeyFrame(1f, to);
        fade.Duration = TimeSpan.FromMilliseconds(ms);
        el.StartAnimation(fade);
    }

    private static void AnimateScale(UIElement el, float scale, float damping = 0.65f)
    {
        var spring = Comp.CreateSpringVector3Animation();
        spring.Target = nameof(UIElement.Scale);
        spring.FinalValue = new Vector3(scale, scale, 1f);
        spring.DampingRatio = damping;
        spring.Period = TimeSpan.FromMilliseconds(40);
        el.CenterPoint = new Vector3(el.ActualSize.X / 2, el.ActualSize.Y / 2, 0);
        el.StartAnimation(spring);
    }

    private static void AnimateTranslation(UIElement el, float y)
    {
        var spring = Comp.CreateSpringVector3Animation();
        spring.Target = "Translation";
        spring.FinalValue = new Vector3(0, y, 0);
        spring.DampingRatio = 0.8f;
        spring.Period = TimeSpan.FromMilliseconds(40);
        el.StartAnimation(spring);
    }

    private void Card_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
        AnimateScale(TileRoot, 1.01f);
        AnimateScale(TileImage, 1.01f);          // slightly more than the card = parallax
        //AnimateTranslation(HoverPanel, 0f);      // slide up into place
        //AnimateOpacity(HoverPanel, 1f);
    }

    private void Card_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        AnimateScale(TileRoot, 1.0f);
        AnimateScale(TileImage, 1.0f);
        //AnimateTranslation(HoverPanel, 12f);
        //AnimateOpacity(HoverPanel, 0f);
    }
}