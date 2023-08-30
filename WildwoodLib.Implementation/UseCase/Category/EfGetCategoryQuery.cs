using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCase.Entity;
using WildwoodLib.Application.UseCase.Entity.Category;
using static WildwoodLib.Application.UseCase.Entity.Category.Category;

namespace WildwoodLib.Implementation.UseCase.Category
{
    public class EfGetCategoryQuery : UseCaseContext, IGetCategoryQuery
    {
        public EfGetCategoryQuery(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 17;

        public PagedResponse<CategoryDto> Execute(BasePagedSearch search)
        {
            var query = Context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }
            query = query.Where(x => x.IsDeleted == null);

            return query.ToPagedResponse(search, x => new CategoryDto
            {
                CategoryId = x.Id,
                Name = x.Name,
            });
        }
    }
}
