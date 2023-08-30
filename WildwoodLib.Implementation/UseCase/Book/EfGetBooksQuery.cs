using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCase.Entity;
using WildwoodLib.Application.UseCase.Entity.Book;
using WildwoodLib.Application.UseCases.Entity.User;
using static WildwoodLib.Application.UseCase.Entity.Book.Book;

namespace WildwoodLib.Implementation.UseCase.Book
{
    public class EfGetBooksQuery : UseCaseContext, IGetBooksQuery
    {
        public EfGetBooksQuery(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 13;

        public PagedResponse<BookDto> Execute(BookSearchDto search)
        {
            var result = Context.Books.AsQueryable();
            
            var category = Context.Categories.AsQueryable();


            if (!string.IsNullOrEmpty(search.TitleKeyword))
            {
                result = result.Where(book => book.Title.Contains(search.TitleKeyword));
            }

            if (!string.IsNullOrEmpty(search.WriterKeyword))
            {
                result = result.Where(book => 
                book.Writer.FirstName.Contains(search.WriterKeyword) ||
                book.Writer.LastName.Contains(search.WriterKeyword)
                );
            }

            if (!string.IsNullOrEmpty(search.CategoryKeyword))
            {
                result = result.Where(book => book.Category.Name.Contains(search.CategoryKeyword));
            }

            result = result.Where(x => x.IsDeleted == null);
            return result.ToPagedResponse(search, x => new BookDto
            {
                BookId = x.Id,
                Title = x.Title,
                Quantity = x.Quantity,
                Writer = x.Writer.FirstName + " " + x.Writer.LastName,
                Category = x.Category.Name
            });
        }
    }
}
