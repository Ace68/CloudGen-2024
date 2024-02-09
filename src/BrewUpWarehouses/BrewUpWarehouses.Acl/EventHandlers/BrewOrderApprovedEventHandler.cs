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
		var correlationId =
			new Guid(@event.UserProperties.FirstOrDefault(u => u.Key.Equals("CorrelationId")).Value.ToString()!);

		var createShippingOrder = new CreateShippingOrder(@event.BrewOrderId, correlationId, @event.Rows);
		await serviceBus.SendAsync(createShippingOrder, cancellationToken);
	}
}