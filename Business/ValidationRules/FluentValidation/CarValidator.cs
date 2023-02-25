using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class CarValidator : AbstractValidator<Car>
{
    public CarValidator()
    {
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Description).MinimumLength(3);
        RuleFor(c => c.DailyPrice).GreaterThan(0);
        RuleFor(c => c.DailyPrice).LessThanOrEqualTo(700).When(c=>c.BrandId==2);
        RuleFor(c => c.BrandId).NotEmpty();
    }
}