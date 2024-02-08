using BrewUpSales.Domain.Aggregates;
using BrewUpSales.Shared.BindingContracts;
using BrewUpSales.Shared.CustomTypes;

namespace BrewUpSales.Domain.Helpers;

public static class DomainHelper
{
	public static IEnumerable<BrewRow> ToEntity(this IEnumerable<BrewOrderRow> rows)
	{
		return rows.Select(row =>
			BrewRow.Create(new BeerId(new Guid(row.BeerId)), new BeerName(row.BeerName), row.Quantity, row.Price));
	}
}