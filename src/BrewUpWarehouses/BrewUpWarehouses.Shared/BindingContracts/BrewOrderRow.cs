namespace BrewUpWarehouses.Shared.BindingContracts;

public class BrewOrderRow
{
	public string BeerId { get; set; } = string.Empty;
	public string BeerName { get; set; } = string.Empty;

	public Quantity Quantity { get; set; } = new Quantity(0, string.Empty);
	public Price Price { get; set; } = new Price(0, string.Empty);
}