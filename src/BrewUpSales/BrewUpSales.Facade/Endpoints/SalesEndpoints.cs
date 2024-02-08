using BrewUpSagas.Facade.Validators;
using BrewUpSales.Shared.BindingContracts;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace BrewUpSales.Facade.Endpoints;

public static class SalesEndpoints
{
	public static IEndpointRouteBuilder MapReceiverEndpoints(this IEndpointRouteBuilder endpoints)
	{
		var group = endpoints.MapGroup("/v1/sales/")
			.WithTags("Sales");

		group.MapPost("breworders", HandleReceiveBrewOrder)
			.Produces(StatusCodes.Status200OK)
			.Produces(StatusCodes.Status500InternalServerError)
			.WithName("ReceiveBrewOrders");

		group.MapGet("breworders", HandleGetBrewOrders)
			.Produces(StatusCodes.Status200OK)
			.Produces(StatusCodes.Status500InternalServerError)
			.WithName("GetBrewOrders");

		return endpoints;
	}

	public static async Task<IResult> HandleGetBrewOrders(ISalesFacade receiverFacade,
		CancellationToken cancellationToken)
	{
		var brewOrdersResult = await receiverFacade.GetBrewOrdersAsync(cancellationToken);

		return Results.Ok(brewOrdersResult.Results);
	}

	public static async Task<IResult> HandleReceiveBrewOrder(ISalesFacade receiverFacade,
		IValidator<BrewOrderContract> validator,
		ValidationHandler validationHandler,
		BrewOrderContract body,
		 CancellationToken cancellationToken)
	{
		await validationHandler.ValidateAsync(validator, body);
		if (!validationHandler.IsValid)
			return Results.BadRequest(validationHandler.Errors);

		await receiverFacade.ReceiveBrewOrderAsync(body, cancellationToken);
		return Results.Ok();
	}
}