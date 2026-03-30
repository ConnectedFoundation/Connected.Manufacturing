using Connected.Entities;

namespace Connected.Manufacturing.Analytics;

public interface IKpi
	: IEntity<long>
{
	DateTimeOffset Created { get; init; }
	double? Value { get; init; }
	int Offset { get; init; }
}
