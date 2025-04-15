using Connected.Authentication;
using Connected.Common.Types.Numbering.Incremental;
using Connected.Common.Types.Numbering.Incremental.Dtos;
using Connected.Manufacturing.ProductionOrders.Dtos;
using Connected.Services;

namespace Connected.Manufacturing.ProductionOrders.ValueProviders;

internal sealed class InsertProductionOrderValuesProvider(IIncrementalNumberService numbering, IAuthenticationService authentication)
	: DtoValuesProvider<IInsertProductionOrderDto>
{
	protected override async Task OnInvoke()
	{
		if (Dto.Code is null)
			await ProvideCode();

		if (Dto.Owner is null)
			await ProvideOwner();
	}

	private async Task ProvideOwner()
	{
		var identity = await authentication.SelectIdentity();

		if (identity is not null)
			Dto.Owner = identity.Token;
	}

	private async Task ProvideCode()
	{
		var dto = Dto.Create<IIncrementalNumberDto>();

		dto.Key = "Production Order";

		Dto.Code = $"PO-{DateTimeOffset.UtcNow.Year}-{await numbering.Next(dto)}";
	}
}
