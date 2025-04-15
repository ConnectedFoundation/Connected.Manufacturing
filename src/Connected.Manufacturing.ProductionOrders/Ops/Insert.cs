using Connected.Entities;
using Connected.Manufacturing.ProductionOrders.Dtos;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Manufacturing.ProductionOrders.Ops;
internal sealed class Insert(IStorageProvider storage, IEventService events, IProductionOrderService productionOrders)
	: ServiceFunction<IInsertProductionOrderDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = await storage.Open<ProductionOrder>().Update(Dto.AsEntity<ProductionOrder>(State.New)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await events.Inserted(this, productionOrders, entity.Id);

		return entity.Id;
	}
}
