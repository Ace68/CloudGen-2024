namespace BrewUpSales.Shared.BindingContracts;

public class BrewOrderContract
{
	public string BrewOrderNumber { get; set; } = string.Empty;

	public DateTime ReceivedOn { get; set; } = DateTime.MinValue;
	public IEnumerable<BrewOrderRow> Rows { get; set; } = Enumerable.Empty<BrewOrderRow>();

	public string OrderStatus { get; set; } = string.Empty;
}