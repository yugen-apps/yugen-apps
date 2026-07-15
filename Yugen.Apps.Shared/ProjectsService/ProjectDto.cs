using System.Collections.Generic;

namespace Yugen.Apps.Shared.ProjectsService;

public class ProjectDto
{
	public int Id { get; set; }

	public string ImageSrc { get; set; }

	public string Title { get; set; }

	public string Description { get; set; }

	public List<LinkDto> Links { get; set; }
}