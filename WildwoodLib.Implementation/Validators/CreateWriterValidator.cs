using FluentValidation;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCase.Entity.Writter;

namespace WildwoodLib.Implementation.Validators
{
    public class CreateWriterValidator : AbstractValidator<CreateWriterDto>
    {
        private WildwoodLibContext _context;
        public CreateWriterValidator(WildwoodLibContext context)
        {
            _context = context;

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.");

            RuleFor(x => x.CountryOfBirth).MaximumLength(256);
        }
    }
}
