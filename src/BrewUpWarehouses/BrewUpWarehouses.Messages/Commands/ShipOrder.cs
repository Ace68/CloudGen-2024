using BrewUpWarehouses.Shared.DomainIds;
using Muflone.Messages.Commands;

namespace BrewUpWarehouses.Messages.Commands;

public sealed class ShipOrder(BrewOrderId aggregateId, Guid commitId) : Command(aggregateId, commitId)
{
	public readonly BrewOrderId BrewOrderId = aggregateId;
}