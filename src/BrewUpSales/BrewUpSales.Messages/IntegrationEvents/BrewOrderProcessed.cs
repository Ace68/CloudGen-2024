using BrewUpSales.Shared.DomainIds;
using Muflone.Messages.Events;

namespace BrewUpSales.Messages.IntegrationEvents;

public sealed class BrewOrderProcessed(BrewOrderId aggregateId, Guid correlationId) : IntegrationEvent(aggregateId, correlationId)
{
	public readonly BrewOrderId BrewOrderId = aggregateId;
}