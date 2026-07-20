using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Yugen.Apps.Shared.ProjectsService;

namespace Yugen.Apps.Web.Components.Pages.Home;

public partial class Home
{
    [Inject]
    public HttpClient Http { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public IProjectsService ProjectsService { get; set; }

    private List<ProjectObservableObject> projects;

    protected override async Task OnInitializedAsync()
    {
        var fileContent = await Http.GetStringAsync("assets/data/projects.json");
        var projectDtos = ProjectsService.GetFromText(fileContent);
        projects = projectDtos.Select(dto => new ProjectObservableObject(dto)).ToList();
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
}
