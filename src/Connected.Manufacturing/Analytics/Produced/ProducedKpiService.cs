using Connected.Manufacturing.Analytics.Dtos;
using Connected.Manufacturing.Analytics.Produced.Dtos;
using Connected.Manufacturing.Analytics.Produced.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Manufacturing.Analytics.Produced;
internal sealed class ProducedKpiService(IServiceProvider services)
		: Service(services), IProducedKpiService
{
	public async Task Delete(IPrimaryKeyDto<long> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<long> Insert(IInsertProducedKpiDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<IProducedKpi>> Query(IQueryOrganizationUnitKpisDto dto)
	{
		return await Invoke(GetOperation<Query>(), dto);
	}

	public async Task<IProducedKpi?> Select(IPrimaryKeyDto<long> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateProducedKpiDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}
