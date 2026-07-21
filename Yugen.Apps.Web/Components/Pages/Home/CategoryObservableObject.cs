using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace Yugen.Apps.Web.Components.Pages.Home;

public partial class CategoryObservableObject : ObservableObject
{
    [ObservableProperty]
    public partial List<ProjectObservableObject> Projects { get; set; } = [];

    [ObservableProperty]
    public partial string Title { get; set; }
}
