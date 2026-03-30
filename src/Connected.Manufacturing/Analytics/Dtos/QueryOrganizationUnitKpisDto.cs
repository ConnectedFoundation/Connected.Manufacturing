namespace Connected.Manufacturing.Analytics.Dtos;

internal class QueryOrganizationUnitKpisDto
	: QueryKpisDto, IQueryOrganizationUnitKpisDto
{
	public List<int>? OrganizationUnits { get; set; }
}
