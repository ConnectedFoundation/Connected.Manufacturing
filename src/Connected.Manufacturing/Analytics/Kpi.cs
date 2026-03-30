using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Manufacturing.Analytics;
internal abstract record Kpi
	: ConsistentEntity<long>, IKpi
{
	[Ordinal(0), Index(false), Date(DateKind.DateTime2, 7)]
	public DateTimeOffset Created { get; init; }

	[Ordinal(1)]
	public double? Value { get; init; }

	[Ordinal(2), Index(false)]
	public int Offset { get; init; }
}
