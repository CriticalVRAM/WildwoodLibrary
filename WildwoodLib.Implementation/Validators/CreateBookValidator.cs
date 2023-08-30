using FluentValidation;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCase.Entity.Book;

namespace WildwoodLib.Implementation.Validators
{
    public class CreateBookValidator : AbstractValidator<CreateBookDto>
    {
        private WildwoodLibContext _context;
        public CreateBookValidator(WildwoodLibContext context)
        {
            _context = context;

            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(2).WithMessage("Title lenght must be more then two characters.");

            RuleFor(x => x.Quantity)
                .Must(quantity => quantity > -1).WithMessage("Quantity must not be negative.");

            RuleFor(x => x.WriterId)
                .NotEmpty().WithMessage("WriterId is required.")
                .Must(writer => _context.Writers.Find(writer) != null).WithMessage("Writer doesn't exsist.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("CategoryId is required.")
                .Must(category => _context.Categories.Find(category) != null).WithMessage("Category doesn't exsist.");
        }
    }
}
