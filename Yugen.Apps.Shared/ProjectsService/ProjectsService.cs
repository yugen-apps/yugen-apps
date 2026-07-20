using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Yugen.Apps.Shared.ProjectsService;

public class ProjectsService : IProjectsService
{
    private readonly JsonSerializerOptions JsonSerializerOptions = new(JsonSerializerDefaults.Web);

    public List<ProjectDto> GetFromText(string text) =>
        JsonSerializer.Deserialize<List<ProjectDto>>(text, JsonSerializerOptions) ?? [];

    public List<ProjectDto> GetFromPath(string path)
    {
        //var directory = Directory.GetCurrentDirectory();
        //var path = Path.Combine(directory, fileRelativePath);
        var fileText = File.ReadAllText(path);
        return GetFromText(fileText);
    }
}
