using Connected.Annotations;
using Connected.Manufacturing.Documents.ProductionOrders.Dtos;

namespace Connected.Manufacturing.Documents.ProductionOrders;

[Service, ServiceUrl(ProductionOrdersUrls.ProductionOrders)]
public interface IProductionOrderService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertProductionOrderDto dto);

	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	[ServiceUrl("select-by-workflow")]
	Task<IProductionOrder> Select(ISelectProductionOrderByWorkflowDto dto);
}
