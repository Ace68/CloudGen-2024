using BrewUpWarehouses.Domain.CommandHandlers;
using BrewUpWarehouses.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUpWarehouses.Infrastructures.RabbitMq.Commands;

public class CreateShippingOrderConsumer(IRepository repository, IMufloneConnectionFactory connectionFactory,
		ILoggerFactory loggerFactory)
	: CommandConsumerBase<CreateShippingOrder>(repository, connectionFactory, loggerFactory)
{
	protected override ICommandHandlerAsync<CreateShippingOrder> HandlerAsync { get; } = new CreateShippingOrderCommandHandler(repository, loggerFactory);
}