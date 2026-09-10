using MudBlazor;

namespace Yugen.Apps.Web.Components.Pages.Home;

public static class IconHelper
{
    public static string TypeToIcon(string type)
    {
        return type switch
        {
            "Blazor" => Icons.Custom.Brands.MudBlazor,
            "Code" => Icons.Material.Outlined.Code,
            "Discord" => Icons.Custom.Brands.Discord,
            "Docs" => Icons.Material.Outlined.Book,
            "Facebook" => Icons.Custom.Brands.Facebook,
            "GitHub" => Icons.Custom.Brands.GitHub,
            "LinkedIn" => Icons.Custom.Brands.LinkedIn,
            "Nuget" => Icons.Custom.Brands.Microsoft,
            "Store" => Icons.Custom.Brands.MicrosoftWindows,
            "Walkthroughs" => Icons.Material.Outlined.QuestionMark,
            "Website" => Icons.Material.Outlined.Link,
            "X" => Icons.Custom.Brands.X,
            _ => Icons.Material.Outlined.Link,
        };
    }
}