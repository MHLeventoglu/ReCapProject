using FluentValidation;

namespace Core.CrossCuttingConcern.Validation;

public static class ValidationTool
{
    public static void Validate(IValidator validator, Object entity)
    {
        var context = new ValidationContext<Object>(entity);
        var result = validator.Validate(context);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);   
        }
    }
}