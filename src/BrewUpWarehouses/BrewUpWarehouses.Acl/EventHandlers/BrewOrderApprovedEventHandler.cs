using BrewUpWarehouses.Messages.Commands;
using BrewUpWarehouses.Messages.IntegrationEvents;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;

namespace BrewUpWarehouses.Acl.EventHandlers;

public sealed class BrewOrderApprovedEventHandler
	(ILoggerFactory loggerFactory, IServiceBus serviceBus) : IntegrationEventHandlerAsync<BrewOrderApproved>(loggerFactory)
{
	public override async Task HandleAsync(BrewOrderApproved @event, CancellationToken cancellationToken = new())
	{
		var createShippingOrder = new CreateShippingOrder(@event.BrewOrderId, @event.MessageId, @event.Rows);
		await serviceBus.SendAsync(createShippingOrder, cancellationToken);
	}
}