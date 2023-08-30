using WildwoodLib.Application.UseCases.Entity.User;

namespace WildwoodLib.Application.UseCase.Entity.Book
{
    public class Book
    {
        public interface IGetBooksQuery : IQuery<BookSearchDto, PagedResponse<BookDto>> { }
        public interface ICreateBookCommand : ICommand<CreateBookDto> { }
        public interface IUpdateBookCommand : ICommand<UpdateBookDto> { }
        public interface IDeleteBookCommand : ICommand<int> { }
    }
}
