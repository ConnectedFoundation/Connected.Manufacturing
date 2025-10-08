using Connected.Manufacturing.ProductionOrders.Dtos;
using Connected.Manufacturing.ProductionOrders.Ops;
using Connected.Services;

namespace Connected.Manufacturing.ProductionOrders;

internal sealed class ProductionOrderService(IServiceProvider services)
	: Service(services), IProductionOrderService
{
	public async Task<int> Insert(IInsertProductionOrderDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public Task<IProductionOrder> Select(ISelectProductionOrderByWorkflowDto dto)
	{
		throw new NotImplementedException();
	}
}