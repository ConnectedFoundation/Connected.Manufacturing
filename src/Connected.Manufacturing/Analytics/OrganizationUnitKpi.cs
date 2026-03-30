using Connected.Annotations;
using Connected.Annotations.Entities;

namespace Connected.Manufacturing.Analytics;
internal abstract record class OrganizationUnitKpi
	: Kpi, IOrganizationUnitKpi
{
	[Ordinal(3), Index(true)]
	public int OrganizationUnit { get; init; }
}
