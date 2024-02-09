using BrewUpWarehouses.Acl.EventHandlers;
using BrewUpWarehouses.Messages.IntegrationEvents;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUpWarehouses.Infrastructures.RabbitMq.Events;

public sealed class BrewOrderApprovedConsumer(IMufloneConnectionFactory mufloneConnectionFactory,
		ILoggerFactory loggerFactory) : IntegrationEventsConsumerBase<BrewOrderApproved>(mufloneConnectionFactory, loggerFactory)
{
	protected override IEnumerable<IIntegrationEventHandlerAsync<BrewOrderApproved>> HandlersAsync { get; } = new List<IIntegrationEventHandlerAsync<BrewOrderApproved>>
	{
		new BrewOrderApprovedEventHandler(loggerFactory, new ServiceBus(mufloneConnectionFactory, loggerFactory))
	};
}