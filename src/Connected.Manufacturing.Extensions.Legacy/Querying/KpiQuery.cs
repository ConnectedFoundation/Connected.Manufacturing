using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Connected.Manufacturing.Extensions.Legacy.Serialization;
internal abstract class KpiQuery
{
	public const string ContentType = "application/json";
	private static readonly JsonSerializerOptions _options;

	static KpiQuery()
	{
		_options = new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};
	}

	private AsyncServiceScope? Scope { get; set; } = default!;
	protected HttpContext Context { get; private set; } = default!;
	protected JsonNode Arguments { get; private set; } = default!;
	public async Task Invoke(HttpContext context, AsyncServiceScope? scope, JsonNode requestArgs)
	{
		Context = context;
		Arguments = requestArgs;
		Scope = scope;

		await OnInvoke();
	}

	protected T GetService<T>()
		where T : notnull
	{
		if (Scope is null)
			throw new NullReferenceException();

		return Scope.Value.ServiceProvider.GetRequiredService<T>();
	}

	protected T GetArgument<T>(string name)
	{
		var node = Arguments[name] ?? throw new InvalidOperationException($"Argument '{name}' is missing.");

		return node.GetValue<T>()!;
	}

	protected T GetArgument<T>(string name, T defaultValue)
	{
		var node = Arguments[name];

		if (node is null)
			return defaultValue;

		return node.GetValue<T>()!;
	}

	protected virtual async Task OnInvoke()
	{
		await Task.CompletedTask;
	}

	protected async Task Serialize<T>(IImmutableList<T> items)
	{
		using var ms = new MemoryStream();

		await JsonSerializer.SerializeAsync(ms, items, _options);

		ms.Seek(0, SeekOrigin.Begin);

		var length = ms.Length;
		var buffer = ms.ToArray();

		Context.Response.ContentLength = length;

		if (length == 0)
			Context.Response.ContentType = "text/plain";
		else
			Context.Response.ContentType = ContentType;

		if (buffer is not null)
			await Context.Response.Body.WriteAsync(buffer);

		await Context.Response.CompleteAsync();
	}
}
