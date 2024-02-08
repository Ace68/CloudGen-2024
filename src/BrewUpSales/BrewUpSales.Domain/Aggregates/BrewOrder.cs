using BrewUpSales.Domain.Helpers;
using BrewUpSales.Messages.DomainEvents;
using BrewUpSales.Shared.BindingContracts;
using BrewUpSales.Shared.CustomTypes;
using BrewUpSales.Shared.DomainIds;
using BrewUpSales.Shared.Enums;
using Muflone.Core;

namespace BrewUpSales.Domain.Aggregates;

public class BrewOrder : AggregateRoot
{
	private BrewOrderId _brewOrderId;
	private BrewOrderNumber _brewOrderNumber;

	private ReceivedOn _receivedOn;

	private IEnumerable<BrewRow> _rows;

	private BrewOrderStatus _brewOrderStatus;

	protected BrewOrder()
	{
	}

	internal static BrewOrder ReceiveBrewOrder(BrewOrderId brewOrderId, Guid correlationId,
		BrewOrderNumber brewOrderNumber, ReceivedOn receivedOn, IEnumerable<BrewOrderRow> rows)
	{
		var brewOrder = new BrewOrder(brewOrderId, correlationId, brewOrderNumber, receivedOn, rows);
		return brewOrder;
	}

	private BrewOrder(BrewOrderId brewOrderId, Guid correlationId, BrewOrderNumber brewOrderNumber,
		ReceivedOn receivedOn, IEnumerable<BrewOrderRow> rows)
	{
		RaiseEvent(new BrewOrderReceived(brewOrderId, correlationId, brewOrderNumber, receivedOn, rows,
			BrewOrderStatus.Received));
	}

	private void Apply(BrewOrderReceived @event)
	{
		Id = @event.BrewOrderId;

		_brewOrderId = @event.BrewOrderId;
		_brewOrderNumber = @event.BrewOrderNumber;

		_receivedOn = @event.ReceivedOn;
		_rows = @event.Rows.ToEntity();

		_brewOrderStatus = @event.BrewOrderStatus;
	}

	internal void CloseBrewOrder(Guid correlationId)
	{
		RaiseEvent(new BrewOrderClosed(_brewOrderId, correlationId));
	}

	private void Apply(BrewOrderClosed @event)
	{
		_brewOrderStatus = BrewOrderStatus.Processed;
	}
}