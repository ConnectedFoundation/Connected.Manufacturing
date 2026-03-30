using Connected.Services;

namespace Connected.Manufacturing.Analytics.Dtos;
internal abstract class KpiDto
	: Dto, IKpiDto
{
	public double? Value { get; set; }
}
