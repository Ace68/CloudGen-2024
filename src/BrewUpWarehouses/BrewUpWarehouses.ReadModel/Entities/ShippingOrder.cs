using BrewUpWarehouses.ReadModel.Abstracts;
using BrewUpWarehouses.Shared.BindingContracts;
using BrewUpWarehouses.Shared.DomainIds;
using BrewUpWarehouses.Shared.Enums;

namespace BrewUpWarehouses.ReadModel.Entities;

public class ShippingOrder : EntityBase
{
	public IEnumerable<BrewOrderRow> Rows { get; private set; }
	public string Status { get; private set; }

	protected ShippingOrder()
	{
	}

	public static ShippingOrder CreateShippingOrder(BrewOrderId brewOrderId, IEnumerable<BrewOrderRow> rows) =>
		new(brewOrderId.Value.ToString(), rows);

	private ShippingOrder(string brewOrderId, IEnumerable<BrewOrderRow> rows)
	{
		Id = brewOrderId;
		Rows = rows;
		Status = ShippingOrderStatus.Open.Name;
	}

	internal void ShipOrder()
	{
		if (!Equals(Status, ShippingOrderStatus.Open.Name))
			return;

		Status = ShippingOrderStatus.Shipped.Name;
	}
}