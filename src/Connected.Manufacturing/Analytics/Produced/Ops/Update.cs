using Connected.Entities;
using Connected.Manufacturing.Analytics.Produced.Dtos;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Manufacturing.Analytics.Produced.Ops;
internal sealed class Update(IStorageProvider storage, IEventService events, IProducedKpiService produced)
	: ServiceAction<IUpdateProducedKpiDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await produced.Select(Dto) as ProducedKpi).Required();

		await storage.Open<ProducedKpi>().Update(entity.Merge(Dto, State.Update), Dto, async () =>
		{
			return SetState(await produced.Select(Dto) as ProducedKpi).Required();
		}, Caller);

		await events.Updated(this, produced, entity.Id);
	}
}
