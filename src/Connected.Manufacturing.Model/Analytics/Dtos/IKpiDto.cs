using Connected.Services;

namespace Connected.Manufacturing.Analytics.Dtos;
public interface IKpiDto
	: IDto
{
	double? Value { get; set; }
}
