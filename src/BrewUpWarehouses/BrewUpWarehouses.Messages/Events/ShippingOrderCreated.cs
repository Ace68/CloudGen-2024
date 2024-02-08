using BrewUpWarehouses.Shared.BindingContracts;
using BrewUpWarehouses.Shared.DomainIds;
using Muflone.Messages.Events;

namespace BrewUpWarehouses.Messages.Events;

public sealed class ShippingOrderCreated(BrewOrderId aggregateId, Guid commitId, IEnumerable<BrewOrderRow> rows) : DomainEvent(aggregateId, commitId)
{
	public readonly BrewOrderId BrewOrderId = aggregateId;
	public readonly IEnumerable<BrewOrderRow> Rows = rows;
}