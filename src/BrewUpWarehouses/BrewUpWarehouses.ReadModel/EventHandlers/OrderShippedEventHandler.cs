using BrewUpWarehouses.Messages.Events;
using BrewUpWarehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUpWarehouses.ReadModel.EventHandlers;

public class OrderShippedEventHandler(ILoggerFactory loggerFactory, IShippingOrderService shippingOrderService)
	: DomainEventHandlerAsync<OrderShipped>(loggerFactory)
{
	public override Task HandleAsync(OrderShipped @event, CancellationToken cancellationToken = new())
	{
		throw new NotImplementedException();
	}
}