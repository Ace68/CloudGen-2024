namespace BrewUpWarehouses.Shared.Enums;

public sealed class ShippingOrderStatus : Enumeration
{
	public static ShippingOrderStatus Open = new(1, "OP", "Open");
	public static ShippingOrderStatus Shipped = new(2, "SH", "Shipped");

	public static IEnumerable<ShippingOrderStatus> List() => new[]
	{
		Open,
		Shipped
	};

	public ShippingOrderStatus(int id, string code, string name) : base(id, code, name)
	{
	}

	public static ShippingOrderStatus FromName(string name)
	{
		var element = List().SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

		if (element == null)
			throw new Exception($"Possible values for ShippingOrderStatus: {string.Join(",", List().Select(s => s.Name))}");

		return element;
	}

	public static ShippingOrderStatus FromCode(string code)
	{
		var element = List().SingleOrDefault(s => string.Equals(s.Code, code, StringComparison.CurrentCultureIgnoreCase));

		if (element == null)
			throw new Exception($"Possible values for ShippingOrderStatus: {string.Join(",", List().Select(s => s.Code))}");

		return element;
	}

	public static ShippingOrderStatus From(int id)
	{
		var element = List().SingleOrDefault(s => s.Id == id);

		if (element == null)
			throw new Exception($"Possible values for ModuleNames: {string.Join(",", List().Select(s => s.Name))}");

		return element;
	}
}