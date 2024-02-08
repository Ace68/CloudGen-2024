using BrewUpSales.Shared.BindingContracts;
using BrewUpSales.Shared.CustomTypes;
using BrewUpSales.Shared.DomainIds;
using BrewUpSales.Shared.Enums;
using Muflone.Messages.Events;

namespace BrewUpSales.Messages.DomainEvents;

public sealed class BrewOrderReceived(BrewOrderId aggregateId, Guid commitId, BrewOrderNumber brewOrderNumber,
		ReceivedOn receivedOn, IEnumerable<BrewOrderRow> rows, BrewOrderStatus brewOrderStatus)
	: DomainEvent(aggregateId, commitId)
{
	public readonly BrewOrderId BrewOrderId = aggregateId;
	public readonly BrewOrderNumber BrewOrderNumber = brewOrderNumber;

	public readonly ReceivedOn ReceivedOn = receivedOn;
	public readonly IEnumerable<BrewOrderRow> Rows = rows;

	public readonly BrewOrderStatus BrewOrderStatus = brewOrderStatus;
}