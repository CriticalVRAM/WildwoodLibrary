using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCase.Entity;
using WildwoodLib.Application.UseCase.Entity.UserUseCase;
using static WildwoodLib.Application.UseCase.Entity.UserUseCase.UserUseCase;

namespace WildwoodLib.Implementation.UseCase.UserUseCase
{
    public class EfGetUserUseCasesQuery : UseCaseContext, IGetUserUseCaseQuery
    {
        public EfGetUserUseCasesQuery(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 9;

        public PagedResponse<UserUseCaseDto> Execute(UserUseCaseSearchDto search)
        {
            var query = Context.UserUseCases.AsQueryable();

            if (search.UserId != null) query = query.Where(x => x.UserId.Equals(search.UserId));
            if (search.UseCaseId != null) query = query.Where(x => x.Equals(search.UseCaseId));
            query = query.Where(x => x.IsDeleted == null);

            return query.ToPagedResponse(search, x => new UserUseCaseDto
            {
                UserId = x.UserId,
                UseCaseId = x.UseCaseId,
            });
        }
    }
}
