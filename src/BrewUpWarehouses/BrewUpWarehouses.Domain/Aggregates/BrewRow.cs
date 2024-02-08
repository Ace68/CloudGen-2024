using BrewUpWarehouses.Shared.BindingContracts;
using BrewUpWarehouses.Shared.CustomTypes;
using Muflone.Core;

namespace BrewUpWarehouses.Domain.Aggregates;

public class BrewRow : Entity
{
	private BeerId _beerId;
	private BeerName _beerName;
	private Quantity _quantity;
	private Price _price;

	protected BrewRow()
	{
	}

	internal static BrewRow Create(BeerId beerId, BeerName beerName, Quantity quantity, Price price)
	{
		return new BrewRow(beerId, beerName, quantity, price);
	}

	private BrewRow(BeerId beerId, BeerName beerName, Quantity quantity, Price price)
	{
		_beerId = beerId;
		_beerName = beerName;
		_quantity = quantity;
		_price = price;
	}
}