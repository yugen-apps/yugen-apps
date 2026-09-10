using System.Collections.Generic;

namespace Yugen.Apps.Shared.ProjectsService;

public interface IProjectsService
{
    List<CategoryDto> GetFromText(string text);

    List<CategoryDto> GetFromPath(string path);
}