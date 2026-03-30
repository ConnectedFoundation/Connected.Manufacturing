
namespace Connected.Manufacturing.Extensions.Legacy.Transactions;
internal sealed class ProducedTransaction
	: KpiTransaction
{
	protected override async Task OnInvoke()
	{
		foreach (var item in Items)
		{

		}
	}
}
