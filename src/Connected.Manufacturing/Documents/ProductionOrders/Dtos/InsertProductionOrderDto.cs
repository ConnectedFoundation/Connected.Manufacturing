using Connected.Annotations;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Manufacturing.ProductionOrders.Dtos;
internal sealed class InsertProductionOrderDto : EntityDto, IInsertProductionOrderDto
{
	[MaxLength(128)]
	public string? Code { get; set; }

	[MinValue(1)]
	public int Workflow { get; set; }

	[MinValue(0)]
	public double Quantity { get; set; }

	[MaxLength(128)]
	public string? Owner { get; set; }

	public ProductionOrderStatus Status { get; set; } = ProductionOrderStatus.Draft;

	public DateTimeOffset? PlannedStart { get; set; }

	public DateTimeOffset? PlannedEnd { get; set; }
}
