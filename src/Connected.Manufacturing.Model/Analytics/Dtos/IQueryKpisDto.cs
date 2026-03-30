using Connected.Services;

namespace Connected.Manufacturing.Analytics.Dtos;
public interface IQueryKpisDto
	: IQueryDto
{
	DateTimeOffset? Start { get; set; }
	DateTimeOffset? End { get; set; }
	int Offset { get; set; }
}
