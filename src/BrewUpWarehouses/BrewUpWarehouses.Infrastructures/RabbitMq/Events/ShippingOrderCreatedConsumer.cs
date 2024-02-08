using BrewUpWarehouses.Messages.Events;
using BrewUpWarehouses.ReadModel.EventHandlers;
using BrewUpWarehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUpWarehouses.Infrastructures.RabbitMq.Events;

public class ShippingOrderCreatedConsumer(IShippingOrderService shippingOrderService, IMufloneConnectionFactory connectionFactory,
		ILoggerFactory loggerFactory)
	: DomainEventsConsumerBase<ShippingOrderCreated>(connectionFactory, loggerFactory)
{
	protected override IEnumerable<IDomainEventHandlerAsync<ShippingOrderCreated>> HandlersAsync { get; } =
		new List<IDomainEventHandlerAsync<ShippingOrderCreated>>
		{
			new ShippingOrderCreatedEventHandler(loggerFactory, shippingOrderService)
		};
}