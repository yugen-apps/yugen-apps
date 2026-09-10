using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Yugen.Apps.Shared.ProjectsService;

namespace Yugen.Apps.Shared;

[JsonSourceGenerationOptions(JsonSerializerDefaults.Web)]
[JsonSerializable(typeof(List<CategoryDto>))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}
