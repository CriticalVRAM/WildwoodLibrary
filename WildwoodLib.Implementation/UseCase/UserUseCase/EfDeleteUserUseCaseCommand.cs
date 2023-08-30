using WildwoddLib.DataAccess;
using WildwoodLib.Application.Exceptions;
using WildwoodLib.Application.UseCase.Entity.UserUseCase;
using static WildwoodLib.Application.UseCase.Entity.UserUseCase.UserUseCase;

namespace WildwoodLib.Implementation.UseCase.UserUseCase
{
    public class EfDeleteUserUseCaseCommand : UseCaseContext, IDeleteUserUseCaseCommand
    {
        public EfDeleteUserUseCaseCommand(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 11;

        public void Execute(DeleteUserUseCaseDto request)
        {
            var query = Context.UserUseCases.AsQueryable();
            query = query.Where(x => x.UserId == request.UserId && x.UseCaseId == request.UseCaseId);
            if (query.Any() == false) throw new EntityNotFoundException();

            var UserUseCase = query.First();
            var IsDeleted = UserUseCase.IsDeleted;
            if (IsDeleted == null) UserUseCase.IsDeleted = DateTime.UtcNow;
            else if (IsDeleted != null) UserUseCase.IsDeleted = null;
            Context.SaveChanges();
        }
    }
}
