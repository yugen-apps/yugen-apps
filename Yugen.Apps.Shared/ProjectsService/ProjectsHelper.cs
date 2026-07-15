namespace Yugen.Apps.Shared.ProjectsService;

public static class ProjectsHelper
{
	public static string GetHref(string type, string value)
	{
		return type switch
		{
			"Discord" => $"https://www.discord.gg/{value}",
			"Docs" => $"{value}",
			"Facebook" => $"https://www.facebook.com/{value}",
			"GitHub" => $"https://www.github.com/{value}",
			"LinkedIn" => $"https://www.linkedin.com/in/{value}",
			"Nuget" => $"https://www.nuget.org/profiles/{value}",
			"Store" => $"https://www.microsoft.com/store/apps/{value}",
			"Walkthroughs" => $"{value}",
			"Website" => $"{value}",
			"X" => $"https://www.x.com/{value}",
			_ => $"{value}",
		};
	}
}
