using CommunityToolkit.Mvvm.ComponentModel;
using FluentIcons.Common;
using Yugen.Apps.Shared.ProjectsService;

namespace Yugen.Apps.WinUi.Views.Main;

public partial class LinkObservableObject : ObservableObject
{
	private readonly LinkDto _model;

	public LinkObservableObject(LinkDto model)
	{
		_model = model;
		Href = ProjectsHelper.GetHref(_model.Type, _model.Value);
		IconName = _model.Type switch
		{
			//"Discord" => Icon.Discord,
			"Docs" => Icon.Book,
			//"Facebook" => Icon.Facebook,
			//"GitHub" => Icon.GitHub,
			//"LinkedIn" => Icon.LinkedIn,
			//"Nuget" => Icon.Microsoft,
			//"Store" => Icon.MicrosoftWindows,
			"Walkthroughs" => Icon.Question,
			"Website" => Icon.Link,
			//"X" => Icon.X,
			_ => Icon.Link,
		};
	}

	public string Type => _model.Type;

	public string Value => _model.Value;

	public Icon IconName { get; }

	public string Href { get; }
}
