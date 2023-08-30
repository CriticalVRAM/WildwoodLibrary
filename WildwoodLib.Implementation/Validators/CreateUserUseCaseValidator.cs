using FluentValidation;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCase.Entity.UserUseCase;

namespace WildwoodLib.Implementation.Validators
{
    public class CreateUserUseCaseValidator : AbstractValidator<CreateUserUseCaseDto>
    {
        private WildwoodLibContext _context;
        public CreateUserUseCaseValidator(WildwoodLibContext context)
        {
            _context = context;

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserID is required.")
                .Must(userid => _context.Users.Where(y => y.Id == userid).Any()).WithMessage("User doesn't exist.");

            RuleFor(x => x.UseCaseId)
                .NotEmpty().WithMessage("UseCaseID is required.");
        }    
    }
}
