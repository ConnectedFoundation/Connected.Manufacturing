
using Connected.Manufacturing.Analytics.Dtos;
using Connected.Manufacturing.Analytics.Produced;

namespace Connected.Manufacturing.Extensions.Legacy.Serialization;
internal sealed class ProducedQuery
	: KpiQuery
{
	protected override async Task OnInvoke()
	{
		var service = GetService<IProducedKpiService>();
		var dto = GetService<IQueryOrganizationUnitKpisDto>();

		dto.Start = GetArgument<DateTimeOffset>("start");
		dto.End = GetArgument<DateTimeOffset>("end");

		await Serialize(await service.Query(dto));
	}
}
