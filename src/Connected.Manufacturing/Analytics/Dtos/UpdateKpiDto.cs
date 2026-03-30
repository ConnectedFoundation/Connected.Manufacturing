using Connected.Annotations;

namespace Connected.Manufacturing.Analytics.Dtos;
internal class UpdateKpiDto
	: KpiDto, IUpdateKpiDto
{
	[MinValue(1)]
	public long Id { get; set; }
}
