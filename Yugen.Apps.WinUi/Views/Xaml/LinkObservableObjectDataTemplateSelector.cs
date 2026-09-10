using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Yugen.Apps.WinUi.Views.Main;

namespace Yugen.Apps.WinUi.Views.Xaml;

public partial class LinkObservableObjectDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate AccentTemplate { get; set; }

    public DataTemplate DefaultTemplate { get; set; }

    protected override DataTemplate SelectTemplateCore(object item)
    {
        if (item is not LinkObservableObject link)
        {
            return base.SelectTemplateCore(item);
        }
        return link.ShowCommandText ? AccentTemplate : DefaultTemplate;
    }
}