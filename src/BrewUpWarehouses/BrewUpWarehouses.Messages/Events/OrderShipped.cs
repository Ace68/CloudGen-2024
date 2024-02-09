using BrewUpWarehouses.Shared.DomainIds;
using Muflone.Messages.Events;

namespace BrewUpWarehouses.Messages.Events;

public sealed class OrderShipped(BrewOrderId aggregateId, Guid commitId) : DomainEvent(aggregateId, commitId)
{
	public readonly BrewOrderId BrewOrderId = aggregateId;
}