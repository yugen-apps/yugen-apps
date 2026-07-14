using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Yugen.Apps.Web.Components.Pages.Home;

public partial class Home
{
	[Inject]
	public HttpClient Http { get; set; }

	[Inject]
	public IDialogService DialogService { get; set; }

	private Project[] projects;

	protected override async Task OnInitializedAsync()
	{
		projects = await Http.GetFromJsonAsync<Project[]>("assets/data/projects.json");
	}

	private async Task OpenDialogAsync(string description)
	{
		var options = new DialogOptions
		{
			CloseOnEscapeKey = true,
			CloseButton = true
		};

		await DialogService.ShowMessageBoxAsync(
		  null,
		  description,
		  null,
		  options: options);
	}

	private static string GetIconName(string type)
	{
		return type switch
		{
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

	private static string GetLink(string type, string value)
	{
		return type switch
		{
			"Discord" => $"https://www.discord.gg/{value}",
			"Docs" => $"{value}",
			"Facebook" => $"https://www.facebook.com/{value}",
			"GitHub" => $"https://www.github.com/{value}",
			"LinkedIn" => $"https://www.linkedin.com/in/{value}",
			"Nuget" => $"https://www.nuget.org/profiles/{value}",
			"Store" => $"https://www.microsoft.com/store/apps/{value}",
			"Walkthroughs" => $"{value}",
			"Website" => $"{value}",
			"X" => $"https://www.x.com/{value}",
			_ => $"{value}",
		};
	}
}
