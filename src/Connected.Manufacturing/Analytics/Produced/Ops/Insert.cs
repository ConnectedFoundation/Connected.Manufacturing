using Connected.Entities;
using Connected.Manufacturing.Analytics.Produced.Dtos;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Manufacturing.Analytics.Produced.Ops;
internal sealed class Insert(IStorageProvider storage, IEventService events, IProducedKpiService produced)
	: ServiceFunction<IInsertProducedKpiDto, long>
{
	protected override async Task<long> OnInvoke()
	{
		var entity = SetState(await storage.Open<ProducedKpi>().Update(Dto.AsEntity<ProducedKpi>(State.Add))).Required();

		await events.Inserted(this, produced, entity.Id);

		return entity.Id;
	}
}
