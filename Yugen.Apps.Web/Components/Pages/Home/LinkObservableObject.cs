using CommunityToolkit.Mvvm.ComponentModel;
using MudBlazor;
using Yugen.Apps.Shared.ProjectsService;

namespace Yugen.Apps.Web.Components.Pages.Home;

public class LinkObservableObject : ObservableObject
{
	private readonly LinkDto _model;

	public LinkObservableObject(LinkDto model)
	{
		_model = model;
		Href = ProjectsHelper.GetHref(_model.Type, _model.Value);
		IconName = _model.Type switch
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

	public string Type => _model.Type;

	public string Value => _model.Value;

	public string IconName { get; }

	public string Href { get; }
}
