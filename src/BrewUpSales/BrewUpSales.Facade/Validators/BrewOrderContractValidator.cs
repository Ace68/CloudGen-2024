using BrewUpSales.Shared.BindingContracts;
using FluentValidation;

namespace BrewUpSales.Facade.Validators;

public class BrewOrderContractValidator : AbstractValidator<BrewOrderContract>
{
	public BrewOrderContractValidator()
	{
		RuleFor(v => v.BrewOrderNumber).NotEmpty();
		RuleFor(v => v.ReceivedOn).GreaterThan(DateTime.MinValue);

		RuleForEach(v => v.Rows).SetValidator(new BrewOrderRowValidator());
	}
}