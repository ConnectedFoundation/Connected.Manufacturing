namespace Connected.Manufacturing.Analytics.Dtos;
public interface IInsertOrganizationUnitKpiDto
	: IInsertKpiDto
{
	int OrganizationUnit { get; set; }
}
