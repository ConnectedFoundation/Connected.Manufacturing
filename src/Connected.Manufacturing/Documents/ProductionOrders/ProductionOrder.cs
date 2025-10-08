using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Manufacturing.ProductionOrders;

[Table(Schema = SchemaAttribute.ManufacturingSchema)]
internal sealed record ProductionOrder : EntityContainer<int>, IProductionOrder
{
	[Ordinal(0), Length(128)]
	public required string Code { get; init; }

	[Ordinal(1), Index(false)]
	public int Workflow { get; init; }

	[Ordinal(2)]
	public double Quantity { get; init; }

	[Ordinal(3), Length(128)]
	public string? Owner { get; init; }

	[Ordinal(4)]
	public ProductionOrderStatus Status { get; init; }

	[Ordinal(5), Date(DateKind.DateTime)]
	public DateTimeOffset? PlannedStart { get; init; }

	[Ordinal(6), Date(DateKind.DateTime)]
	public DateTimeOffset? PlannedEnd { get; init; }
}
