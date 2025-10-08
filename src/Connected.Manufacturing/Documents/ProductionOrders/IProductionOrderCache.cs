using Connected.Caching;

namespace Connected.Manufacturing.ProductionOrders;
internal interface IProductionOrderCache : ICacheContainer<ProductionOrder, int>
{
}
