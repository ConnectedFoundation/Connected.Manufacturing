namespace Connected.Manufacturing.Analytics.Dtos;
public interface IInsertKpiDto
	: IKpiDto
{
	DateTimeOffset Created { get; set; }
	int Offset { get; set; }
}
