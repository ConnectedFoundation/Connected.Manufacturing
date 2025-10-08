using Connected.Services;

namespace Connected.Manufacturing.ProductionOrders.Dtos;

public interface IInsertProductionOrderDto : IEntityDto
{
	string? Code { get; set; }
	int Workflow { get; set; }
	double Quantity { get; set; }
	string? Owner { get; set; }
	ProductionOrderStatus Status { get; set; }
	DateTimeOffset? PlannedStart { get; set; }
	DateTimeOffset? PlannedEnd { get; set; }
}
