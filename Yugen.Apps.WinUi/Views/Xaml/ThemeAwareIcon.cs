using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;

namespace Yugen.Apps.WinUi.Views.Xaml;

public static class ThemeAwareIcon
{
    public static readonly DependencyProperty IconIdProperty =
      DependencyProperty.RegisterAttached(
          "IconId", 
          typeof(string), 
          typeof(ThemeAwareIcon),
          new PropertyMetadata(null, OnIconIdChanged));

    public static string GetIconId(ImageIcon obj) => (string)obj.GetValue(IconIdProperty);

    public static void SetIconId(ImageIcon obj, string value) => obj.SetValue(IconIdProperty, value);

    private static void OnIconIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not ImageIcon image) return;

        image.ActualThemeChanged -= OnThemeChanged;
        image.ActualThemeChanged += OnThemeChanged;
        UpdateSource(image);
    }

    private static void OnThemeChanged(FrameworkElement sender, object args)
        => UpdateSource((ImageIcon)sender);

    private static void UpdateSource(ImageIcon image)
    {
        var id = GetIconId(image);
        if (string.IsNullOrEmpty(id))
        {
            image.Source = null;
            return;
        }
        var theme = image.ActualTheme == ElementTheme.Dark ? "Dark" : "Light";
        image.Source = new SvgImageSource(
            new Uri($"ms-appx:///Assets/Img/Icons/{id}_{theme}.svg"));
    }
}