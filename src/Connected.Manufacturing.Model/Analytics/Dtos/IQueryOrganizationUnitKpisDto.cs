namespace Connected.Manufacturing.Analytics.Dtos;
public interface IQueryOrganizationUnitKpisDto
	: IQueryKpisDto
{
	List<int>? OrganizationUnits { get; set; }
}
