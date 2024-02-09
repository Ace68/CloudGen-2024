using BrewUpWarehouses.Domain.Aggregates;
using BrewUpWarehouses.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUpWarehouses.Domain.CommandHandlers;

public sealed class ShipOrderCommandHandler : CommandHandlerBaseAsync<ShipOrder>
{
	public ShipOrderCommandHandler(IRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
	{
	}

	public override async Task ProcessCommand(ShipOrder command, CancellationToken cancellationToken = default)
	{
		var aggregate = await Repository.GetByIdAsync<ShippingOrder>(command.BrewOrderId.Value);
		aggregate.ShipOrder();

		await Repository.SaveAsync(aggregate, Guid.NewGuid());
	}
}