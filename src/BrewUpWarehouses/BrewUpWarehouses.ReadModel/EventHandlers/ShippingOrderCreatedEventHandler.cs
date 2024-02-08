using BrewUpWarehouses.Messages.Events;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUpWarehouses.ReadModel.EventHandlers;

public sealed class ShippingOrderCreatedEventHandler : DomainEventHandlerAsync<ShippingOrderCreated>
{
	public ShippingOrderCreatedEventHandler(ILoggerFactory loggerFactory) : base(loggerFactory)
	{
	}

	public override Task HandleAsync(ShippingOrderCreated @event, CancellationToken cancellationToken = new())
	{
		throw new NotImplementedException();
	}
}