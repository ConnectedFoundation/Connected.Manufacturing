using Connected.Annotations;
using Connected.Authentication;
using Connected.Authorization.Services;
using Connected.Manufacturing.ProductionOrders.Dtos;
using Connected.Manufacturing.ProductionOrders.Extensions;
using Connected.Membership.Claims;
using Connected.Services;

namespace Connected.Manufacturing.ProductionOrders.Authorization;

[Middleware<IProductionOrderService>(nameof(IProductionOrderService.Insert))]
internal sealed class InsertProductionOrderAuthorization(IClaimService claims, IAuthenticationService authentication) : ServiceOperationAuthorization<IInsertProductionOrderDto>
{
	protected override async Task OnInvoke()
	{
		var dto = Dto.Create<IRequestClaimDto>();

		dto.Claims = ProductionOrderClaims.CreateProductionOrder;
		dto.Identity = (await authentication.SelectIdentity())?.Token;

		if (!await claims.Request(dto))
			throw new UnauthorizedAccessException();
	}
}
