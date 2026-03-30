using Connected.Annotations;
using Connected.Manufacturing.Analytics.Dtos;
using Connected.Manufacturing.Analytics.Produced.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Manufacturing.Analytics.Produced;

[Service, ServiceUrl(ManufacturingRouting.ProducedKpis)]
public interface IProducedKpiService
{
	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task<long> Insert(IInsertProducedKpiDto dto);

	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task Update(IUpdateProducedKpiDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<long> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IProducedKpi?> Select(IPrimaryKeyDto<long> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IProducedKpi>> Query(IQueryOrganizationUnitKpisDto dto);
}
