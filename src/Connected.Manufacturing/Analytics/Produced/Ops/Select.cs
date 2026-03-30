using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Manufacturing.Analytics.Produced.Ops;
internal sealed class Select(IStorageProvider storage)
	: ServiceFunction<IPrimaryKeyDto<long>, IProducedKpi?>
{
	protected override async Task<IProducedKpi?> OnInvoke()
	{
		return await storage.Open<ProducedKpi>().AsEntity(f => f.Id == Dto.Id);
	}
}
