using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        
    }
}