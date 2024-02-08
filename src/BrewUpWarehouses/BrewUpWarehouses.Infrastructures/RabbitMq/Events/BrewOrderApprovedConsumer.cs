using BrewUpWarehouses.Messages.IntegrationEvents;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUpWarehouses.Infrastructures.RabbitMq.Events;

public sealed class BrewOrderApprovedConsumer : IntegrationEventsConsumerBase<BrewOrderApproved>
{
	protected override IEnumerable<IIntegrationEventHandlerAsync<BrewOrderApproved>> HandlersAsync { get; }

	public BrewOrderApprovedConsumer(IMufloneConnectionFactory mufloneConnectionFactory, ILoggerFactory loggerFactory) : base(mufloneConnectionFactory, loggerFactory)
	{
	}
}