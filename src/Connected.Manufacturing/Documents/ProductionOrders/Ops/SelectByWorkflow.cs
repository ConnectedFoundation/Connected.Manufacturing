using Connected.Entities;
using Connected.Manufacturing.ProductionOrders.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Manufacturing.ProductionOrders.Ops;
internal sealed class SelectByWorkflow(IProductionOrderCache cache, IStorageProvider storage)
	: ServiceFunction<ISelectProductionOrderByWorkflowDto, IProductionOrder?>
{
	protected override async Task<IProductionOrder?> OnInvoke()
	{
		return await cache.Get(f => f.Workflow == Dto.Workflow, async (f) =>
		{
			return await storage.Open<ProductionOrder>().AsEntity(f => f.Workflow == Dto.Workflow);
		});
	}
}
