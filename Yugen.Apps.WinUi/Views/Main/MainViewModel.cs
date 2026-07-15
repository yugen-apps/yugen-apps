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

	[ObservableProperty]
	public partial List<ProjectObservableObject> Projects { get; set; } = [];

	public MainViewModel(IProjectsService projectsService)
	{
		_projectsService = projectsService;
	}

	[RelayCommand]
	private async Task Load()
	{
		var filePath = $"{Package.Current.InstalledLocation.Path}\\Assets\\Data\\projects.json";
		var projectDtos = _projectsService.GetFromPath(filePath);
		Projects = projectDtos.Select(dto => new ProjectObservableObject(dto)).ToList();
	}
}
