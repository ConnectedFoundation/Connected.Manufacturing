using Connected.Annotations;

namespace Connected.Manufacturing.Analytics.Dtos;
internal abstract class InsertKpiDto
	: KpiDto, IInsertKpiDto
{
	[NonDefault]
	public DateTimeOffset Created { get; set; }

	[MinValue(0)]
	public int Offset { get; set; }
}
