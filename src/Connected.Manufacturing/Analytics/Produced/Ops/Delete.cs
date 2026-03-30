using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Manufacturing.Analytics.Produced.Ops;
internal sealed class Delete(IStorageProvider storage, IEventService events, IProducedKpiService produced)
	: ServiceAction<IPrimaryKeyDto<long>>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await produced.Select(Dto) as ProducedKpi).Required();

		await storage.Open<ProducedKpi>().Update(entity.WithState(State.Delete));
		await events.Deleted(this, produced, entity.Id);
	}
}
