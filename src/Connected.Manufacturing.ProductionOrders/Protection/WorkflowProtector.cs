using Connected.Entities.Protection;
using Connected.Manufacturing.ProductionOrders.Dtos;
using Connected.Processes.Workflows;
using Connected.Services;

namespace Connected.Manufacturing.ProductionOrders.Protection;
internal sealed class WorkflowProtector(IProductionOrderService productionOrders) : EntityProtector<IWorkflow>
{
	protected override async Task OnInvoke()
	{
		var dto = Dto.Factory.Create<ISelectProductionOrderByWorkflowDto>();

		dto.Workflow = Entity.Id;

		if (await productionOrders.Select(dto) is not null)
			throw new InvalidOperationException(SR.ErrWorkflowproductionOrderExists);
	}
}
