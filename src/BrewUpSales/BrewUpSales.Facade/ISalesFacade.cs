using BrewUpSales.ReadModel.Abstracts;
using BrewUpSales.Shared.BindingContracts;

namespace BrewUpSales.Facade;

public interface ISalesFacade
{
	Task<PagedResult<BrewOrderContract>> GetBrewOrdersAsync(CancellationToken cancellationToken);
	Task<string> ReceiveBrewOrderAsync(BrewOrderContract brewOrder, CancellationToken cancellationToken);
}