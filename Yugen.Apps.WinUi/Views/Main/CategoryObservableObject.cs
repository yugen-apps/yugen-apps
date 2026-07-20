using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yugen.Apps.WinUi.Views.Main;

public partial class CategoryObservableObject : ObservableObject
{
    [ObservableProperty]
    public partial List<ProjectObservableObject> Projects { get; set; } = [];

    [ObservableProperty]
    public partial string Title { get; set; }
}