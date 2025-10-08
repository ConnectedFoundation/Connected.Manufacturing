using Connected.Annotations.Entities;

namespace Connected.Manufacturing.ProductionOrders;
public static class ProductionOrdersMetaData
{
	public const string ProductionOrderKey = $"{SchemaAttribute.ManufacturingSchema}.{nameof(IProductionOrder)}";
}
