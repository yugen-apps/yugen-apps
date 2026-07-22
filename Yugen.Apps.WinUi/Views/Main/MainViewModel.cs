using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Yugen.Apps.Shared.ProjectsService;

namespace Yugen.Apps.WinUi.Views.Main;

public partial class MainViewModel : ObservableObject
{
    private readonly IProjectsService _projectsService;

    public MainViewModel(IProjectsService projectsService)
    {
        _projectsService = projectsService;
    }

    [ObservableProperty]
    public partial List<CategoryObservableObject> AllCategories { get; set; } = [];

    [ObservableProperty]
    public partial CategoryObservableObject SelectedCategory { get; set; }

    [RelayCommand]
    private async Task Load()
    {
        var filePath = $"{Package.Current.InstalledLocation.Path}\\Assets\\Data\\projects.json";
        var categoryDtos = _projectsService.GetFromPath(filePath);
        AllCategories = categoryDtos.Select(x => x.ToCategoryObservableObject()).ToList();
        SelectedCategory = AllCategories[0];
    }
}