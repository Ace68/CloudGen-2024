using BrewUpWarehouses.ReadModel.Abstracts;
using BrewUpWarehouses.ReadModel.Entities;
using BrewUpWarehouses.Shared.BindingContracts;
using BrewUpWarehouses.Shared.DomainIds;
using Microsoft.Extensions.Logging;

namespace BrewUpWarehouses.ReadModel.Services;

public sealed class ShippingOrderService : BaseService, IShippingOrderService
{
	public ShippingOrderService(IPersister persister, ILoggerFactory loggerFactory) : base(persister, loggerFactory)
	{
	}

	public async Task CreateShippingOrderAsync(BrewOrderId brewOrderId, IEnumerable<BrewOrderRow> rows, CancellationToken cancellationToken)
	{
		var entity = ShippingOrder.CreateShippingOrder(brewOrderId, rows);
		await Persister.InsertAsync(entity, cancellationToken);
	}
}