using Connected.Entities;
using Connected.Manufacturing.Analytics.Dtos;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Manufacturing.Analytics.Produced.Ops;
internal sealed class Query(IStorageProvider storage)
	: ServiceFunction<IQueryOrganizationUnitKpisDto, IImmutableList<IProducedKpi>>
{
	protected override async Task<IImmutableList<IProducedKpi>> OnInvoke()
	{
		return await storage.Open<ProducedKpi>().WithDto(Dto).AsEntities<IProducedKpi>(f => (Dto.Start is null || f.Created >= Dto.Start)
			&& (Dto.End is null || f.Created <= Dto.End)
			&& f.Offset == Dto.Offset
			&& (Dto.OrganizationUnits is null || Dto.OrganizationUnits.Any(g => g == f.OrganizationUnit)));
	}
}
