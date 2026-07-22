using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace Yugen.Apps.WinUi.Views.Main;

public partial class CategoryObservableObject : ObservableObject
{
    [ObservableProperty]
    public partial List<ProjectObservableObject> Projects { get; set; } = [];

    [ObservableProperty]
    public partial string Title { get; set; }

    [ObservableProperty]
    public partial string Type { get; set; }
}