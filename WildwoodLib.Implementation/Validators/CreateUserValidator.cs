using FluentValidation;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCases.Entity.User;

namespace WildwoodLib.Implementation.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        private WildwoodLibContext _context;
        public CreateUserValidator(WildwoodLibContext context)
        {
            _context = context;


            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.");

            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Username must be longer than 3 characters.")
                .Must(username => !_context.Users.Any(x => x.Username == username)).WithMessage("Username already taken.");

            RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("E-mail is required.")
                .EmailAddress().WithMessage("Invalid e-mail format.");

            RuleFor(x => x.Password)
                .MinimumLength(7).WithMessage("Password must be longer than 7 characters.");
        }
    }
}
