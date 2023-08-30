using FluentValidation;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCase.Entity.Checkout;

namespace WildwoodLib.Implementation.Validators
{
    public class CreateCheckoutValidator : AbstractValidator<CreateCheckoutDto>
    {
        private WildwoodLibContext _context;
        public CreateCheckoutValidator(WildwoodLibContext context)
        {
            _context = context;

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.")
                .Must(userId => _context.Users.Find(userId) != null).WithMessage("User doesn't exsist.");

            RuleFor(x => x.BookId)
                .NotEmpty().WithMessage("BookId is required.")
                .Must(value => _context.Books.Find(value) != null).WithMessage("Book doesn't exsist.");


            RuleFor(x => x.DateStart)
                .NotEmpty().WithMessage("Start Date is required.")
                .LessThanOrEqualTo(DateTime.Now.AddDays(1)).WithMessage("Start date can't be in the past and must be today or tomorrow.");

            RuleFor(x => x.DateEnd)
                .NotEmpty().WithMessage("End Date is required.")
                .LessThanOrEqualTo(DateTime.Now.AddMonths(1)).WithMessage("End date can't be in the past or farther away than one month from now.");

            RuleFor(x => x.DateEnd)
                .GreaterThan(y => y.DateStart).WithMessage("Start date must be lower than end date.");
        }
    }
}
