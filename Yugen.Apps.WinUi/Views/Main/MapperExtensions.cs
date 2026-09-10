using Riok.Mapperly.Abstractions;
using Yugen.Apps.Shared.ProjectsService;

namespace Yugen.Apps.WinUi.Views.Main;

[Mapper]
public static partial class MapperExtensions
{
    public static partial LinkObservableObject ToLinkObservableObject(this LinkDto dto);

    public static partial ProjectObservableObject ToProjectObservableObject(this ProjectDto dto);

    public static partial CategoryObservableObject ToCategoryObservableObject(this CategoryDto dto);
}