using Connected.Manufacturing.ProductionOrders;
using Connected.Manufacturing.ProductionOrders.Dtos;
using Connected.Manufacturing.ProductionOrders.Extensions;
using Connected.Processes.States;
using Connected.Processes.Workflows.Activities;
using Connected.Services;

namespace Connected.ProductionOrders.Process.States;

//[Middleware<IProductionOrder>()]
internal sealed class OperationStateActionProvider(IProductionOrderService productionOrders, IActivityService activities) : StateActionProvider
{
	protected override async Task OnInvoke()
	{
		var activity = await activities.Select(Dto.CreatePrimaryKey(Dto.Activity));

		if (activity is null)
			return;

		var dto = Dto.Create<ISelectProductionOrderByWorkflowDto>();

		dto.Workflow = activity.Workflow;

		var productionOrder = await productionOrders.Select(dto);

		if (productionOrder is null)
			return;

		ProcessItems(activity, productionOrder);
	}

	private void ProcessItems(IActivity activity, IProductionOrder productionOrder)
	{
		switch (activity.Status)
		{
			case ActivityStatus.Pending:
				Dto.Items.Add(new StateAction(ProductionOrdersActions.ActivateOperation, SR.ActivateOperation));
				break;
			case ActivityStatus.Active:
				Dto.Items.Add(new StateAction(ProductionOrdersActions.CompleteOperation, SR.CompleteOperation));
				break;
			case ActivityStatus.Complete:
				Dto.Items.Add(new StateAction(ProductionOrdersActions.ActivateOperation, SR.ActivateOperation));
				break;
		}
	}
}
