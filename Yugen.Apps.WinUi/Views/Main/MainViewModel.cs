using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.System;
using Yugen.Apps.Shared.ProjectsService;

namespace Yugen.Apps.WinUi.Views.Main;

public partial class MainViewModel : ObservableObject
{
    private readonly IProjectsService _projectsService;

    public MainViewModel(IProjectsService projectsService)
    {
        _projectsService = projectsService;
    }

    public string WindowTitle { get; } = "Yugen Apps";

    [ObservableProperty]
    public partial List<CategoryObservableObject> AllCategories { get; set; } = [];

    [ObservableProperty]
    public partial CategoryObservableObject SelectedCategory { get; set; }

    [ObservableProperty]
    public partial bool IsPopupOpen { get; set; }

    [ObservableProperty]
    public partial Uri WebViewSource { get; set; } = BlankPage;

    public static Uri BlankPage => new("about:blank");

    [RelayCommand]
    private async Task Load()
    {
        var filePath = $"{Package.Current.InstalledLocation.Path}\\Assets\\Data\\projects.json";
        var categoryDtos = _projectsService.GetFromPath(filePath);
        AllCategories = categoryDtos.Select(x => x.ToCategoryObservableObject()).ToList();
        SelectedCategory = AllCategories[0];
    }

    [RelayCommand]
    private async Task LaunchAsync(object href)
    {
        try
        {              

            if (Uri.TryCreate(href as string, UriKind.RelativeOrAbsolute, out var uri))
            {
                WebViewSource = uri;
                if (WebViewSource.Scheme == "https")
                {
                    IsPopupOpen = true;
                }
                else
                {
                    await Launcher.LaunchUriAsync(WebViewSource);
                }
            }
        }
        catch
        {
        }
    }

    [RelayCommand]
    private async Task ClosePopup()
    {
        WebViewSource = BlankPage;
        IsPopupOpen = false;
    }
}