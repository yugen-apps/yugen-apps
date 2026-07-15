using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System.Collections;

namespace Yugen.Apps.WinUi.Adapters;

public static class VisibilityAdapters
{
    public static Visibility And(bool value1, bool value2)
        => Convert(value1 && value2);

    public static Visibility IsProgressVisible(bool starting, int progress)
       => Convert(starting || progress >= 0);

    /// <summary>
    /// Converts a bool value to a Visibility value.
    /// </summary>
    /// <returns>
    /// Visibility.Collapsed if true, else Visibility.Visible.
    /// </returns>
    public static Visibility IsBoolFalse(bool value)
        => Convert(!value);

    /// <summary>
    /// Converts a bool value to a Visibility value.
    /// </summary>
    /// <returns>
    /// Visibility.Visible if true, else Visibility.Collapsed.
    /// </returns>
    public static Visibility IsBoolTrue(bool value)
        => Convert(value);

    public static Visibility IsCollectionEmpty(ICollection collection)
        => Convert(collection?.Count == 0);

    public static Visibility IsEmptyString(string value)
        => Convert(string.IsNullOrWhiteSpace(value));

    /// <summary>
    /// Converts an integer value to a Visibility value.
    /// </summary>
    /// <returns>
    /// <see cref="Visibility.Visible"/> if value is bigger than zero, otherwise, <see cref="Visibility.Collapsed"/>
    /// </returns>
    public static Visibility IsIntegerBiggerThanZero(int value)
        => Convert(value > 0);

    /// <summary>
    /// Converts an integer value to a Visibility value.
    /// </summary>
    /// <returns>
    /// <see cref="Visibility.Visible"/> if value equals or bigger than zero, otherwise, <see cref="Visibility.Collapsed"/>
    /// </returns>
    public static Visibility IsIntegerZeroOrBigger(int value)
        => Convert(value >= 0);

    /// <summary>
    /// Converts an integer value to a Visibility value.
    /// </summary>
    /// <returns>
    /// <see cref="Visibility.Visible"/> if value equals or less than zero, otherwise, <see cref="Visibility.Collapsed"/>
    /// </returns>
    public static Visibility IsIntegerZeroOrLess(int value)
        => Convert(value <= 0);

    /// <summary>
    /// Converts an object value to a Visibility value.
    /// </summary>
    /// <returns>
    /// Visibility.Visible if true, else Visibility.Collapsed.
    /// </returns>
    public static Visibility IsNotNull(object value)
        => Convert(value != null);

    /// <summary>
    /// Converts a string to a Visibility value based on whether it has value and it's not empty
    /// </summary>
    /// <returns>
    /// <see cref="Visibility.Visible"/> if value is not null and a non-empty string, otherwise, <see cref="Visibility.Collapsed"/>
    /// </returns>
    public static Visibility IsValidString(string value)
        => Convert(!string.IsNullOrWhiteSpace(value));

    public static Visibility Or(bool value1, bool value2)
        => Convert(value1 || value2);

    public static Visibility IsViewNotEmpty(ICollectionView view)
        => Convert(view?.Count > 0);

    private static Visibility Convert(bool value)
        => value ? Visibility.Visible : Visibility.Collapsed;
}