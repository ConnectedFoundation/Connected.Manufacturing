using Connected.Annotations.Entities;

namespace Connected.Manufacturing.Analytics.Produced;

[Table(Schema = SchemaAttribute.ManufacturingSchema)]
internal sealed record ProducedKpi
	: OrganizationUnitKpi, IProducedKpi
{
}
