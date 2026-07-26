using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Yugen.Apps.Shared.ProjectsService;

namespace Yugen.Apps.Web.Components.Pages.Home;

public partial class ProjectObservableObject : ObservableObject
{
    private readonly ProjectDto _model;

    public ProjectObservableObject(ProjectDto model)
    {
        _model = model;
        ImageSrc = $"assets/img/cards/{_model.ImageSrc}";
        Links = model.Links.Select(link => new LinkObservableObject(link)).ToList();
    }

    public string Description => _model.Description;

    public string ImageSrc { get; }

    public List<LinkObservableObject> Links { get; }

    public string Title => _model.Title;
}
