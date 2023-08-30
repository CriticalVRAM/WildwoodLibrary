using System.Linq.Expressions;
using WildwoodLib.Application.UseCase.Entity;
using WildwoodLib.Domain.Entites;

namespace WildwoodLib.Implementation
{
    public static class PageResultExtension
    {
        public static PagedResponse<TDto> ToPagedResponse<TEntity, TDto>(
            this IQueryable<TEntity> query,
            PagedSearch search,
            Expression<Func<TEntity, TDto>> conversion)
            where TDto : class
            where TEntity : class
        {
            if (search.PerPage == null || search.PerPage < 1) search.PerPage = 15;
            if (search.Page == null || search.Page < 1) search.Page = 1;

            var ToSkip = (search.Page.Value - 1) * search.PerPage.Value;

            return new PagedResponse<TDto>
            {
                TotalCount = query.Count(),
                CurrentPage = search.Page.Value,
                ItemsPerPage = search.PerPage.Value,
                Data = query.Skip(ToSkip)
                 .Take(search.PerPage.Value)
                 .Select(conversion)
                 .ToList()
            };
        }
    }
}
