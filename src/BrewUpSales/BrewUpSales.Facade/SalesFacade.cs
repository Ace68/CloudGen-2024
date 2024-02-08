using BrewUpSales.Facade.Helpers;
using BrewUpSales.Messages.Commands;
using BrewUpSales.ReadModel.Abstracts;
using BrewUpSales.ReadModel.Services;
using BrewUpSales.Shared.BindingContracts;
using Muflone.Persistence;

namespace BrewUpSales.Facade;

public sealed class SalesFacade(IBrewOrderService brewOrderService, IServiceBus serviceBus) : ISalesFacade
{
	public async Task<PagedResult<BrewOrderContract>> GetBrewOrdersAsync(CancellationToken cancellationToken)
	{
		return await brewOrderService.GetBrewOrdersAsync(cancellationToken);
	}

	public async Task<string> ReceiveBrewOrderAsync(BrewOrderContract brewOrder, CancellationToken cancellationToken)
	{
		ReceiveBrewOrder command = brewOrder.ToCommand();
		await serviceBus.SendAsync(command, cancellationToken);

		return command.BrewOrderId.Value.ToString();
	}
}