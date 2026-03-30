using Connected.Annotations;

namespace Connected.Manufacturing.Analytics.Dtos;
internal class InsertOrganizationUnitKpiDto
	: InsertKpiDto, IInsertOrganizationUnitKpiDto
{
	[MinValue(1)]
	public int OrganizationUnit { get; set; }
}
