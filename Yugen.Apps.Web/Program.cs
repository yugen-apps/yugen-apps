using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Yugen.Apps.Shared.ProjectsService;

namespace Yugen.Apps.Web;

public class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebAssemblyHostBuilder.CreateDefault(args);
		builder.RootComponents.Add<App>("#app");
		builder.RootComponents.Add<HeadOutlet>("head::after");

		builder.Services.AddMudServices();
		builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
		builder.Services.AddSingleton<IProjectsService, ProjectsService>();

		builder.Services.AddCookieConsent(o =>
		{
			o.Revision = 1;
			o.PolicyUrl = "/cookie-policy";
		});

		var app = builder.Build();

		await app.RunAsync();
	}
}
