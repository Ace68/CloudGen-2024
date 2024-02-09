using BrewUpWarehouses.Domain.Helpers;
using BrewUpWarehouses.Messages.Events;
using BrewUpWarehouses.Shared.BindingContracts;
using BrewUpWarehouses.Shared.DomainIds;
using Muflone.Core;

namespace BrewUpWarehouses.Domain.Aggregates;

public class ShippingOrder : AggregateRoot
{
	private BrewOrderId _brewOrderId;
	private IEnumerable<BrewRow> _rows;

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
	}
}