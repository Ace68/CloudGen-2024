using BrewUpSales.Messages.Commands;
using BrewUpSales.Shared.BindingContracts;
using BrewUpSales.Shared.CustomTypes;
using BrewUpSales.Shared.DomainIds;

namespace BrewUpSales.Facade.Helpers;

public static class SalesConverter
{
	public static ReceiveBrewOrder ToCommand(this BrewOrderContract contract)
	{
		return new ReceiveBrewOrder(new BrewOrderId(Guid.NewGuid()), Guid.NewGuid(),
			new BrewOrderNumber(contract.BrewOrderNumber),
			new ReceivedOn(contract.ReceivedOn), contract.Rows);
	}
}