using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Xaml.Interactivity;
using System.Windows.Input;

namespace Yugen.Apps.WinUi.Behaviors;

public sealed class SelectorBarSelectionChangedBehavior : Behavior<SelectorBar>
{
    #region DependencyProperties

    public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
        nameof(Command),
        typeof(ICommand),
        typeof(SelectorBarSelectionChangedBehavior),
        new PropertyMetadata(default(ICommand)));

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    #endregion DependencyProperties

    protected override void OnAttached()
    {
        base.OnAttached();

        if (AssociatedObject != null)
        {
            AssociatedObject.SelectionChanged += HandleSelectionChanged;
        }
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();

        if (AssociatedObject != null)
        {
            AssociatedObject.SelectionChanged -= HandleSelectionChanged;
        }
    }

    private void HandleSelectionChanged(SelectorBar sender, SelectorBarSelectionChangedEventArgs args)
    {
        SelectorBarItem selectedItem = sender.SelectedItem;
        int currentSelectedIndex = sender.Items.IndexOf(selectedItem);

        if (Command is not ICommand command ||
            !command.CanExecute(currentSelectedIndex))
        {
            return;
        }

        command.Execute(currentSelectedIndex);
    }
}