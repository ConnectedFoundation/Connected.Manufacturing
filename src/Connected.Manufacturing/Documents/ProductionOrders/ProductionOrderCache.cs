using Connected.Caching;
using Connected.Manufacturing.Documents.ProductionOrders;

namespace Connected.Manufacturing.ProductionOrders;
internal sealed class ProductionOrderCache(ICachingService cachingService)
	: CacheContainer<ProductionOrder, int>(cachingService, ProductionOrdersMetaData.ProductionOrderKey), IProductionOrderCache
{
}
