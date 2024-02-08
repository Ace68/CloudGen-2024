using BrewUpSales.Shared.BindingContracts;
using BrewUpSales.Shared.DomainIds;
using Muflone.Messages.Events;

namespace BrewUpSales.Messages.IntegrationEvents;

public sealed class BrewOrderApproved(BrewOrderId aggregateId, Guid correlationId, IEnumerable<BrewOrderRow> rows)
	: IntegrationEvent(aggregateId,
	correlationId)
{
	public readonly BrewOrderId BrewOrderId = aggregateId;
	public readonly IEnumerable<BrewOrderRow> Rows = rows;
}