using Connected.Annotations.Entities;
using Connected.Manufacturing.Analytics.Produced;

namespace Connected.Manufacturing;
public static class ManufacturingMetaData
{
	public const string ProducedKpiKey = $"{SchemaAttribute.ManufacturingSchema}.{nameof(IProducedKpi)}";
}
