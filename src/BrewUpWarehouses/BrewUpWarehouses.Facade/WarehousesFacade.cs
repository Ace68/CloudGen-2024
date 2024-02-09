using BrewUpWarehouses.Messages.Commands;
using BrewUpWarehouses.Shared.DomainIds;
using Muflone.Persistence;

namespace BrewUpWarehouses.Facade;

public sealed class WarehousesFacade(IServiceBus serviceBus) : IWarehousesFacade
{
	public async Task ShipOrderAsync(string brewOrderId, CancellationToken cancellationToken)
	{
		var shipOrder = new ShipOrder(new BrewOrderId(new Guid(brewOrderId)), Guid.NewGuid());
		await serviceBus.SendAsync(shipOrder, cancellationToken);
	}
}