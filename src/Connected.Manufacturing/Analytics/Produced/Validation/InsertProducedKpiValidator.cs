using Connected.Common.Types.OrganizationUnits;
using Connected.Manufacturing.Analytics.Produced.Dtos;
using Connected.Services;
using Connected.Services.Validation;

namespace Connected.Manufacturing.Analytics.Produced.Validation;
internal sealed class InsertProducedKpiValidator(IOrganizationUnitService organizationUnits)
	: Validator<IInsertProducedKpiDto>
{
	protected override async Task OnInvoke()
	{
		if (await organizationUnits.Select(Dto.CreatePrimaryKey(Dto.OrganizationUnit)) is null)
			throw ValidationExceptions.NotFound(nameof(Dto.OrganizationUnit), Dto.OrganizationUnit);
	}
}
