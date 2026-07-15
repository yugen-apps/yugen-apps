using System.Collections.Generic;

namespace Yugen.Apps.Shared.ProjectsService;

public interface IProjectsService
{
	List<ProjectDto> GetFromText(string text);

	List<ProjectDto> GetFromPath(string path);
}