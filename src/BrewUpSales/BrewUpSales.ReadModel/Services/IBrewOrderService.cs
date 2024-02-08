﻿using BrewUpSales.ReadModel.Abstracts;
using BrewUpSales.Shared.BindingContracts;
using BrewUpSales.Shared.CustomTypes;
using BrewUpSales.Shared.DomainIds;
using BrewUpSales.Shared.Enums;

namespace BrewUpSales.ReadModel.Services;

public interface IBrewOrderService
{
	Task ReceiveBrewOrderAsync(BrewOrderId aggregateId, BrewOrderNumber brewOrderNumber, ReceivedOn receivedOn,
		IEnumerable<BrewOrderRow> rows, BrewOrderStatus brewOrderStatus,
		CancellationToken cancellationToken = default);

	Task<PagedResult<BrewOrderContract>> GetBrewOrdersAsync(CancellationToken cancellationToken);
	Task CloseBrewOrderAsync(BrewOrderId brewOrderId, CancellationToken cancellationToken);
}