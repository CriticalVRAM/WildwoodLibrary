using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCase.Entity;
using WildwoodLib.Application.UseCases.Entity.User;

namespace WildwoodLib.Implementation.UseCase.User
{
    public class EfGetUsersQuery : UseCaseContext, IGetUsersQuery
    {
        public EfGetUsersQuery(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 1;

        public PagedResponse<UserDto> Execute(BasePagedSearch search)
        {
            var query = Context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Username.Contains(search.Keyword));
            }
            query = query.Where(x => x.IsDeleted == null);

            return query.ToPagedResponse(search, x => new UserDto
            {
                UserId = x.Id,
                Email = x.Email,
                Username = x.Username,
                FirstName = x.FirstName,
                LastName = x.LastName,
            });
        }
    }
}
