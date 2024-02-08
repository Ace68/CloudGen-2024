using BrewUpWarehouses.Shared.BindingContracts;
using BrewUpWarehouses.Shared.DomainIds;
using Muflone.Messages.Commands;

namespace BrewUpWarehouses.Messages.Commands;

public sealed class CreateShippingOrder(BrewOrderId aggregateId, Guid commitId, IEnumerable<BrewOrderRow> rows)
	: Command(aggregateId, commitId)
{
	public readonly BrewOrderId BrewOrderId = aggregateId;
	public readonly IEnumerable<BrewOrderRow> Rows = rows;
}