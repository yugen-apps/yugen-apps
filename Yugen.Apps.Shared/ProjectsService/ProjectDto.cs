using System.Collections.Generic;

namespace Yugen.Apps.Shared.ProjectsService;

public class ProjectDto
{
    public string Caption { get; set; }

    public string Description { get; set; }

    public string ImageSrc { get; set; }

    public List<LinkDto> Links { get; set; }

    public string Org { get; set; }

    public string OrgDisplayName { get; set; }

    public string Title { get; set; }
}