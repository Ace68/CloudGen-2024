using BrewUpWarehouses.ReadModel.Abstracts;
using BrewUpWarehouses.Shared.BindingContracts;
using BrewUpWarehouses.Shared.DomainIds;

namespace BrewUpWarehouses.ReadModel.Entities;

public class ShippingOrder : EntityBase
{
	public IEnumerable<BrewOrderRow> Rows;

	protected ShippingOrder()
	{
	}

	public static ShippingOrder CreateShippingOrder(BrewOrderId brewOrderId, IEnumerable<BrewOrderRow> rows) =>
		new(brewOrderId.Value.ToString(), rows);

	private ShippingOrder(string brewOrderId, IEnumerable<BrewOrderRow> rows)
	{
		Id = brewOrderId;
		Rows = rows;
	}
}