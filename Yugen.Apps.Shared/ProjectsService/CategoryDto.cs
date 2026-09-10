using System.Collections.Generic;

namespace Yugen.Apps.Shared.ProjectsService;

public class CategoryDto
{
    public List<ProjectDto> Projects { get; set; }

    public string Title { get; set; }

    public string Type { get; set; }
}