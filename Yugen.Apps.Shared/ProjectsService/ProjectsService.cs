using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Yugen.Apps.Shared.ProjectsService;

public class ProjectsService : IProjectsService
{
    public List<CategoryDto> GetFromText(string text) =>
        JsonSerializer.Deserialize(text, AppJsonSerializerContext.Default.ListCategoryDto) ?? default;

    public List<CategoryDto> GetFromPath(string path)
    {
        //var directory = Directory.GetCurrentDirectory();
        //var path = Path.Combine(directory, fileRelativePath);
        var fileText = File.ReadAllText(path);
        return GetFromText(fileText);
    }
}