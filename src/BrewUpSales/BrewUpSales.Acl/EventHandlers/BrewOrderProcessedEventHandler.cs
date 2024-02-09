using BrewUpSales.Messages.Commands;
using BrewUpSales.Messages.IntegrationEvents;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;

namespace BrewUpSales.Acl.EventHandlers;

public sealed class BrewOrderProcessedEventHandler
	(ILoggerFactory loggerFactory, IServiceBus serviceBus) : IntegrationEventHandlerAsync<BrewOrderProcessed>(loggerFactory)
{
	public override async Task HandleAsync(BrewOrderProcessed @event, CancellationToken cancellationToken = new())
	{
		var correlationId =
			new Guid(@event.UserProperties.FirstOrDefault(u => u.Key.Equals("CorrelationId")).Value.ToString()!);

		CloseBrewOrder closeBrewOrder = new(@event.BrewOrderId, correlationId);
		await serviceBus.SendAsync(closeBrewOrder, cancellationToken);
	}
}