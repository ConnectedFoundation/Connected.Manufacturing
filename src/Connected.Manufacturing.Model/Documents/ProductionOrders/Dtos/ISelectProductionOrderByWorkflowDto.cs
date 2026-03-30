using Connected.Services;

namespace Connected.Manufacturing.Documents.ProductionOrders.Dtos;
public interface ISelectProductionOrderByWorkflowDto : IDto
{
	int Workflow { get; set; }
}
