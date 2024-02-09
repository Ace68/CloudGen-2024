using BrewUpSales.Acl.EventHandlers;
using BrewUpSales.Messages.IntegrationEvents;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUpSales.Infrastructures.RabbitMq.Events;

public sealed class BrewOrderProcessedConsumer(IServiceBus serviceBus,
		IMufloneConnectionFactory mufloneConnectionFactory, ILoggerFactory loggerFactory)
	: IntegrationEventsConsumerBase<BrewOrderProcessed>(mufloneConnectionFactory, loggerFactory)
{
	protected override IEnumerable<IIntegrationEventHandlerAsync<BrewOrderProcessed>> HandlersAsync { get; } = new List<IIntegrationEventHandlerAsync<BrewOrderProcessed>>
	{
		new BrewOrderProcessedEventHandler(loggerFactory, serviceBus)
	};
}