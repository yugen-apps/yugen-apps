using CommunityToolkit.Mvvm.ComponentModel;
using FluentIcons.Common;
using Yugen.Apps.Shared.ProjectsService;

namespace Yugen.Apps.WinUi.Views.Main;

public partial class LinkObservableObject : ObservableObject
{
    private readonly LinkDto _model;

    public LinkObservableObject(LinkDto model)
    {
        _model = model;
        Href = ProjectsHelper.GetHref(_model.Type, _model.Value);
    }

    public string CommandText => _model.CommandText;

    public string Description => !string.IsNullOrEmpty(_model.Description) ? _model.Description : Href;

    public string Href { get; }

    public Icon IconName { get; }

    public bool ShowCommandText => !string.IsNullOrWhiteSpace(_model.CommandText);

    public string Type => _model.Type;

    public string Value => _model.Value;
}