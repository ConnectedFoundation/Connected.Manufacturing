using Connected.Annotations;
using Connected.Services;

namespace Connected.Manufacturing.Analytics.Dtos;
internal abstract class QueryKpisDto
	: QueryDto, IQueryKpisDto
{
	public DateTimeOffset? Start { get; set; }
	public DateTimeOffset? End { get; set; }

	[MinValue(0)]
	public int Offset { get; set; }
}
