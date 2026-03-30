namespace Connected.Manufacturing.Analytics;
public interface IOrganizationUnitKpi
	: IKpi
{
	int OrganizationUnit { get; init; }
}
