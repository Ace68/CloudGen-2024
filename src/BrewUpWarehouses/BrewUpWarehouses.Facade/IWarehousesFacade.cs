namespace BrewUpWarehouses.Facade;

public interface IWarehousesFacade
{
	Task ShipOrderAsync(string brewOrderId, CancellationToken cancellationToken);
}