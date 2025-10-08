using Connected.Entities;

namespace Connected.Manufacturing.ProductionOrders;

public enum ProductionOrderStatus
{
	Draft = 1,
	Active = 2,
	Complete = 3
}

public interface IProductionOrder : IEntityContainer<int>
{
	string Code { get; init; }
	int Workflow { get; init; }
	double Quantity { get; init; }
	string? Owner { get; init; }
	ProductionOrderStatus Status { get; init; }
	DateTimeOffset? PlannedStart { get; init; }
	DateTimeOffset? PlannedEnd { get; init; }
}
