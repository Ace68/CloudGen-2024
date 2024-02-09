using BrewUpWarehouses.Messages.Events;
using BrewUpWarehouses.Messages.IntegrationEvents;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;

namespace BrewUpWarehouses.Acl.EventHandlers;

public sealed class OrderShippedForIntegrationEventHandler
	(ILoggerFactory loggerFactory, IEventBus eventBus) : DomainEventHandlerAsync<OrderShipped>(loggerFactory)
{

	public override async Task HandleAsync(OrderShipped @event, CancellationToken cancellationToken = new())
	{
		var correlationId =
			new Guid(@event.UserProperties.FirstOrDefault(u => u.Key.Equals("CorrelationId")).Value.ToString()!);

		var brewOrderProcessed = new BrewOrderProcessed(@event.BrewOrderId, correlationId);
		await eventBus.PublishAsync(brewOrderProcessed, cancellationToken);
	}
}