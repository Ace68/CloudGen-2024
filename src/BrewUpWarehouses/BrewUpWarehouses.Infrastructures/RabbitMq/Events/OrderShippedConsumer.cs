using BrewUpWarehouses.Acl.EventHandlers;
using BrewUpWarehouses.Messages.Events;
using BrewUpWarehouses.ReadModel.EventHandlers;
using BrewUpWarehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUpWarehouses.Infrastructures.RabbitMq.Events;

public sealed class OrderShippedConsumer(IShippingOrderService shippingOrderService, IEventBus eventbus,
		IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory)
	: DomainEventsConsumerBase<OrderShipped>(connectionFactory, loggerFactory)
{
	protected override IEnumerable<IDomainEventHandlerAsync<OrderShipped>> HandlersAsync { get; } =
		new List<IDomainEventHandlerAsync<OrderShipped>>
		{
			new OrderShippedEventHandler(loggerFactory, shippingOrderService),
			new OrderShippedForIntegrationEventHandler(loggerFactory, eventbus)
		};
}