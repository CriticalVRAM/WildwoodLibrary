using FluentValidation;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCases.Entity.User;

namespace WildwoodLib.Implementation.Validators
{
    public class EditUserValidator : AbstractValidator<EditUserDto>
    {
        private WildwoodLibContext _context;
        public EditUserValidator(WildwoodLibContext context)
        {
            _context = context;

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.");

            RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("E-mail is required.")
                .EmailAddress().WithMessage("Invalid e-mail format.");

            RuleFor(x => x.Password)
                .MinimumLength(7).WithMessage("Password must be longer than 7 characters.");
        }
    }
}
