using Connected.Services;

namespace Connected.Manufacturing.ProductionOrders.Dtos;
public interface ISelectProductionOrderByWorkflowDto : IDto
{
	int Workflow { get; set; }
}
