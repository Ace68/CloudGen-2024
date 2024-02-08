using BrewUpWarehouses.Messages.Events;
using BrewUpWarehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUpWarehouses.ReadModel.EventHandlers;

public sealed class ShippingOrderCreatedEventHandler(ILoggerFactory loggerFactory,
		IShippingOrderService shippingOrderService) : DomainEventHandlerAsync<ShippingOrderCreated>(loggerFactory)
{

	public override async Task HandleAsync(ShippingOrderCreated @event, CancellationToken cancellationToken = new())
	{
		cancellationToken.ThrowIfCancellationRequested();

		await shippingOrderService.CreateShippingOrderAsync(@event.BrewOrderId, @event.Rows, cancellationToken);
	}
}