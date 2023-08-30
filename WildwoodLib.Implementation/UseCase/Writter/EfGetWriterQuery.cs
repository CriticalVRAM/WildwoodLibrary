using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCase.Entity;
using WildwoodLib.Application.UseCase.Entity.Writter;
using static WildwoodLib.Application.UseCase.Entity.Writter.Writer;

namespace WildwoodLib.Implementation.UseCase.Writter
{
    public class EfGetWriterQuery : UseCaseContext, IGetWritersQuery
    {
        public EfGetWriterQuery(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 5;

        public PagedResponse<WriterDto> Execute(BasePagedSearch search)
        {
            var query = Context.Writers.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.FirstName.Contains(search.Keyword) || x.LastName.Contains(search.Keyword));
            }
            query = query.Where(x => x.IsDeleted == null);

            return query.ToPagedResponse(search, x => new WriterDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                CountryOfBirth = x.CountryOfBirth
            });
        }
    }
}
