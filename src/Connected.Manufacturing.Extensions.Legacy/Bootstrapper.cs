using Connected.Runtime;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Connected.Manufacturing.Extensions.Legacy;
internal sealed class Bootstrapper
	: Startup
{
	protected override void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		app.UseEndpoints(config =>
		{
			config.Map("query/{microservice}/{partition}", async (httpContext) =>
			{
				using var handler = new KpiQueryRequestDelegate(httpContext);

				await handler.Invoke();
			});

			config.Map("data/{microservice}/{partition}", async (httpContext) =>
			{
				using var handler = new KpiTransactionRequestDelegate(httpContext);

				await handler.Invoke();
			});
		});
	}
}
