using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Yugen.Apps.Shared.ProjectsService;
using Yugen.Apps.WinUi.Views.Main;

namespace Yugen.Apps.WinUi;

public partial class MainViewModel : ObservableObject
{
    private readonly IProjectsService _projectsService;

    public MainViewModel(IProjectsService projectsService)
    {
        _projectsService = projectsService;
    }

    [ObservableProperty]
    public partial List<CategoryObservableObject> Categories { get; set; } = [];

    [RelayCommand]
    private async Task Load()
    {
        var filePath = $"{Package.Current.InstalledLocation.Path}\\Assets\\Data\\projects.json";
        var projectDtos = _projectsService.GetFromPath(filePath);
        Categories = projectDtos.Select(dto => new ProjectObservableObject(dto))
            .GroupBy(p => p.Category)
            .Select(c => new CategoryObservableObject { Title = c.Key, Projects = c.ToList() })
            .ToList();
    }
}