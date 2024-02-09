using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace BrewUpWarehouses.Facade.Endpoints;

public static class WarehousesEndpoints
{
	public static IEndpointRouteBuilder MapWarehousesEndpoints(this IEndpointRouteBuilder endpoints)
	{
		var group = endpoints.MapGroup("/v1/warehouses/")
			.WithTags("Warehouses");

		group.MapPut("", HandleShipOder)
			.WithName("ShipOrder");


		return endpoints;
	}

	public static async Task<IResult> HandleShipOder(IWarehousesFacade warehousesFacade,
		string brewOrderId,
		CancellationToken cancellationToken)
	{
		await warehousesFacade.ShipOrderAsync(brewOrderId, cancellationToken);
		return Results.Accepted();
	}
}