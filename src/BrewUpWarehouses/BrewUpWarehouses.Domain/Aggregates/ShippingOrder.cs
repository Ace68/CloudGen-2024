using BrewUpWarehouses.Domain.Helpers;
using BrewUpWarehouses.Messages.Events;
using BrewUpWarehouses.Shared.BindingContracts;
using BrewUpWarehouses.Shared.DomainIds;
using BrewUpWarehouses.Shared.Enums;
using Muflone.Core;

namespace BrewUpWarehouses.Domain.Aggregates;

public class ShippingOrder : AggregateRoot
{
	private BrewOrderId _brewOrderId;
	private IEnumerable<BrewRow> _rows;

	private ShippingOrderStatus _status;

	protected ShippingOrder()
	{
	}

	internal static ShippingOrder CreateShippingOrder(BrewOrderId brewOrderId, Guid correlationId, IEnumerable<BrewOrderRow> rows)
	{
		return new ShippingOrder(brewOrderId, correlationId, rows);
	}

	private ShippingOrder(BrewOrderId brewOrderId, Guid correlationId, IEnumerable<BrewOrderRow> rows)
	{
		RaiseEvent(new ShippingOrderCreated(brewOrderId, correlationId, rows));
	}

	private void Apply(ShippingOrderCreated @event)
	{
		Id = @event.BrewOrderId;
		_brewOrderId = @event.BrewOrderId;
		_rows = @event.Rows.ToEntity();

		_status = ShippingOrderStatus.Open;
	}

	internal void ShipOrder()
	{
		// In a real scenario we have to raise an event to inform the user!!!
		if (!Equals(_status, ShippingOrderStatus.Open))
			return;

		RaiseEvent(new OrderShipped(_brewOrderId, Guid.NewGuid()));
	}

	private void Apply(OrderShipped @event)
	{
		_status = ShippingOrderStatus.Shipped;
	}
}