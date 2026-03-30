using Connected.Services;

namespace Connected.Manufacturing.Analytics.Dtos;
public interface IUpdateKpiDto
	: IKpiDto, IPrimaryKeyDto<long>
{
}
