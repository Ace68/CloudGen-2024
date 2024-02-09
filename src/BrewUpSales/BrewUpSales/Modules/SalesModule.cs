using BrewUpSales.Facade;
using BrewUpSales.Facade.Endpoints;

namespace BrewUpSales.Modules;

public class SalesModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 0;

	public IServiceCollection RegisterModule(WebApplicationBuilder builder)
		=> builder.Services.AddSales();

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
		=> endpoints.MapReceiverEndpoints();
}