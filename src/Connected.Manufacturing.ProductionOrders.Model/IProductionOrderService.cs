using Connected.Annotations;
using Connected.Manufacturing.ProductionOrders.Dtos;

namespace Connected.Manufacturing.ProductionOrders;

[Service, ServiceUrl(ProductionOrdersUrls.ProductionOrders)]
public interface IProductionOrderService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertProductionOrderDto dto);

	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	[ServiceUrl("select-by-workflow")]
	Task<IProductionOrder> Select(ISelectProductionOrderByWorkflowDto dto);
}
