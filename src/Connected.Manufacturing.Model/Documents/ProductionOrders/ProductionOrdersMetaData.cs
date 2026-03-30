using Connected.Annotations.Entities;

namespace Connected.Manufacturing.Documents.ProductionOrders;
public static class ProductionOrdersMetaData
{
	public const string ProductionOrderKey = $"{SchemaAttribute.ManufacturingSchema}.{nameof(IProductionOrder)}";
}
