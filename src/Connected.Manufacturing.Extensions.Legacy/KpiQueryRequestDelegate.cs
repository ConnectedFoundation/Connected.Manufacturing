using Connected.Manufacturing.Extensions.Legacy.Serialization;
using Connected.Net.Rest;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json.Nodes;

namespace Connected.Manufacturing.Extensions.Legacy;
internal sealed class KpiQueryRequestDelegate(HttpContext httpContext)
		: RestRequest(httpContext)
{
	protected override async Task<object?> OnInvoke()
	{
		var microService = HttpContext.Request.RouteValues["microService"]?.ToString();

		if (string.Equals(microService, "Production", StringComparison.OrdinalIgnoreCase))
			await ProcessProduction();

		return null;
	}

	private async Task ProcessProduction()
	{
		var partition = HttpContext.Request.RouteValues["partition"]?.ToString();

		if (string.Equals(partition, "Kpi", StringComparison.OrdinalIgnoreCase))
			await ProcessKpis();
	}

	private async Task ProcessKpis()
	{
		using var reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
		var text = await reader.ReadToEndAsync();

		if (JsonNode.Parse(text, new JsonNodeOptions { PropertyNameCaseInsensitive = true }) is not JsonNode node)
			return;

		var kpi = node["kpi"]?.GetValue<string>();

		if (string.Equals(kpi, "produced", StringComparison.OrdinalIgnoreCase))
			await new ProducedQuery().Invoke(HttpContext, Scope, node);
	}
}
