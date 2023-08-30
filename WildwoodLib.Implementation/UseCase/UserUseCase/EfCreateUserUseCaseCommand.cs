using FluentValidation;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.Exceptions;
using WildwoodLib.Application.UseCase.Entity.UserUseCase;
using WildwoodLib.Implementation.Validators;
using static WildwoodLib.Application.UseCase.Entity.UserUseCase.UserUseCase;

namespace WildwoodLib.Implementation.UseCase.UserUseCase
{
    public class EfCreateUserUseCaseCommand : UseCaseContext, ICreateUserUseCaseCommand
    {
        public EfCreateUserUseCaseCommand(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 10;

        public void Execute(CreateUserUseCaseDto request)
        {
            new CreateUserUseCaseValidator(Context).ValidateAndThrow(request);

            var query = Context.UserUseCases.AsQueryable();
            query = query.Where(x => x.UserId == request.UserId && x.UseCaseId == request.UseCaseId);
            if (query.Any() == true) throw new EntityExistsException();

            var newUUC = new Domain.Entites.UserUseCase
            {
                UserId = request.UserId,
                UseCaseId = request.UseCaseId,
            };
            Context.UserUseCases.Add(newUUC);
            Context.SaveChanges();
        }
    }
}
