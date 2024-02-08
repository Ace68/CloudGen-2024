using BrewUpSales.Shared.BindingContracts;
using FluentValidation;

namespace BrewUpSales.Facade.Validators;

public class BrewOrderRowValidator : AbstractValidator<BrewOrderRow>
{
	public BrewOrderRowValidator()
	{
		RuleFor(v => v.BeerId).NotEmpty();
		RuleFor(v => v.BeerName).NotEmpty();
		RuleFor(v => v.Quantity.Value).GreaterThan(0);
		RuleFor(v => v.Quantity.UnitOfMeasure).NotEmpty();
		RuleFor(v => v.Price.Value).GreaterThan(0);
		RuleFor(v => v.Price.Currency).NotEmpty();
	}
}