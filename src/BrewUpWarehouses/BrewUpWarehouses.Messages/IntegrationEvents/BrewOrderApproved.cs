using BrewUpWarehouses.Shared.BindingContracts;
using BrewUpWarehouses.Shared.DomainIds;
using Muflone.Messages.Events;

namespace BrewUpWarehouses.Messages.IntegrationEvents;

public sealed class BrewOrderApproved(BrewOrderId aggregateId, Guid correlationId, IEnumerable<BrewOrderRow> rows)
	: IntegrationEvent(aggregateId, correlationId)
{
	public readonly BrewOrderId BrewOrderId = aggregateId;
	public readonly IEnumerable<BrewOrderRow> Rows = rows;
}