using Connected.Annotations.Entities;

namespace Connected.Manufacturing.Analytics.Produced;

[EntityKey(ManufacturingMetaData.ProducedKpiKey)]
public interface IProducedKpi
	: IOrganizationUnitKpi
{

}
