using BrewUpWarehouses.Shared.BindingContracts;
using BrewUpWarehouses.Shared.DomainIds;

namespace BrewUpWarehouses.ReadModel.Services;

public interface IShippingOrderService
{
	Task CreateShippingOrderAsync(BrewOrderId brewOrderId, IEnumerable<BrewOrderRow> rows, CancellationToken cancellationToken);
}