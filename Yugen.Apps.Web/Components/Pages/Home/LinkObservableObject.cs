using CommunityToolkit.Mvvm.ComponentModel;
using MudBlazor;
using Yugen.Apps.Shared.ProjectsService;

namespace Yugen.Apps.Web.Components.Pages.Home;

public partial class LinkObservableObject : ObservableObject
{
    private readonly LinkDto _model;

    public LinkObservableObject(LinkDto model)
    {
        _model = model;
        Href = ProjectsHelper.GetHref(_model.Type, _model.Value);
    }

    public string Type => _model.Type;

    public string Value => _model.Value;

    public string Href { get; }
}
