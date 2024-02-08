using BrewUpWarehouses.Messages.IntegrationEvents;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUpWarehouses.Facade.EventHandlers;

public sealed class BrewOrderApprovedEventHandler : IntegrationEventHandlerAsync<BrewOrderApproved>
{
	public BrewOrderApprovedEventHandler(ILoggerFactory loggerFactory) : base(loggerFactory)
	{
	}

	public override Task HandleAsync(BrewOrderApproved @event, CancellationToken cancellationToken = new())
	{
		throw new NotImplementedException();
	}
}