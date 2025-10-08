using Connected.Manufacturing.ProductionOrders.Dtos;
using Connected.Processes.Workflows;
using Connected.Services;
using Connected.Services.Validation;
using System.ComponentModel.DataAnnotations;

namespace Connected.Manufacturing.ProductionOrders.Validation;

internal sealed class InsertProductionOrderValidator(IWorkflowService workflows) : Validator<IInsertProductionOrderDto>
{
	protected override async Task OnInvoke()
	{
		var workflow = await workflows.Select(Dto.CreatePrimaryKey(Dto.Workflow));

		if (workflow is null)
			throw ValidationExceptions.NotFound(nameof(Dto.Workflow), Dto.Workflow);

		if (workflow.Status != Entities.Status.Enabled)
			throw new ValidationException(SR.ValWorkflowDisabled);

		if (Dto.PlannedEnd != DateTimeOffset.MinValue && Dto.PlannedEnd < Dto.PlannedStart)
			throw new ValidationException(SR.ValPlannedEnd);
	}
}
