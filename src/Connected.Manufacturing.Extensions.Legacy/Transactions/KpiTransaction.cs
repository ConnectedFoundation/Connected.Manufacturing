using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Nodes;

namespace Connected.Manufacturing.Extensions.Legacy.Transactions;
internal abstract class KpiTransaction
{
	private AsyncServiceScope? Scope { get; set; } = default!;
	protected HttpContext Context { get; private set; } = default!;
	protected JsonArray Items { get; private set; } = default!;

	public async Task Invoke(HttpContext context, AsyncServiceScope? scope, JsonArray items)
	{
		Context = context;
		Items = items;
		Scope = scope;

		await OnInvoke();
	}

	protected virtual async Task OnInvoke()
	{
		await Task.CompletedTask;
	}

	protected T GetService<T>()
		where T : notnull
	{
		if (Scope is null)
			throw new NullReferenceException();

		return Scope.Value.ServiceProvider.GetRequiredService<T>();
	}
}
