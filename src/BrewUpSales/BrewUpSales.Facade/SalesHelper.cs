using BrewUpSagas.Facade.Validators;
using BrewUpSales.Facade.Validators;
using BrewUpSales.Infrastructures;
using BrewUpSales.ReadModel.Abstracts;
using BrewUpSales.ReadModel.Entities;
using BrewUpSales.ReadModel.Queries;
using BrewUpSales.ReadModel.Services;
using BrewUpSales.Shared.Configurations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUpSales.Facade;

public static class SalesHelper
{
	public static IServiceCollection AddSales(this IServiceCollection services)
	{
		services.AddFluentValidationAutoValidation();
		services.AddValidatorsFromAssemblyContaining<BrewOrderContractValidator>();
		services.AddSingleton<ValidationHandler>();

		services.AddScoped<IBrewOrderService, BrewOrderService>();
		services.AddScoped<IQueries<BrewOrder>, BrewOrderQueries>();
		services.AddScoped<ISalesFacade, SalesFacade>();

		return services;
	}

	public static IServiceCollection AddReceiverInfrastructure(this IServiceCollection services,
		MongoDbSettings mongoDbSettings,
		RabbitMqSettings rabbitMqSettings,
		string eventStoreConnectionString)
	{
		services.AddInfrastructure(mongoDbSettings, rabbitMqSettings, eventStoreConnectionString);

		return services;
	}
}