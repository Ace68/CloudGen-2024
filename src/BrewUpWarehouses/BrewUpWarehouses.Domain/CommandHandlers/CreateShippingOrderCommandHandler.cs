using BrewUpWarehouses.Domain.Aggregates;
using BrewUpWarehouses.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUpWarehouses.Domain.CommandHandlers;

public sealed class CreateShippingOrderCommandHandler : CommandHandlerBaseAsync<CreateShippingOrder>
{
	public CreateShippingOrderCommandHandler(IRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
	{
	}

	public override async Task ProcessCommand(CreateShippingOrder command, CancellationToken cancellationToken = default)
	{
		var aggreagate = ShippingOrder.CreateShippingOrder(command.BrewOrderId, command.MessageId, command.Rows);
		await Repository.SaveAsync(aggreagate, Guid.NewGuid());
	}
}