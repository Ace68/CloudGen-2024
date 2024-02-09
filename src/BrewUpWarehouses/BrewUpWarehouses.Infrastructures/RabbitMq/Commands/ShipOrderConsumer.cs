using BrewUpWarehouses.Domain.CommandHandlers;
using BrewUpWarehouses.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUpWarehouses.Infrastructures.RabbitMq.Commands;

public sealed class ShipOrderConsumer(IRepository repository, IMufloneConnectionFactory connectionFactory,
		ILoggerFactory loggerFactory)
	: CommandConsumerBase<ShipOrder>(repository, connectionFactory, loggerFactory)
{
	protected override ICommandHandlerAsync<ShipOrder> HandlerAsync { get; } = new ShipOrderCommandHandler(repository, loggerFactory);
}