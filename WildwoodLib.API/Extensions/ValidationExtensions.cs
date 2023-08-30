using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WildwoodLib.API.DTO;

namespace WildwoodLib.API.Extensions
{
    public static class ValidationExtensions
    {
        public static UnprocessableEntityObjectResult ToUnprocessableEntity(this ValidationResult result)
        {
            var errors = result.Errors.Select(x => new ClientErrorDto
            {
                Error = x.ErrorMessage,
                Property = x.PropertyName
            });

            return new UnprocessableEntityObjectResult(errors);
        }
    }
}
