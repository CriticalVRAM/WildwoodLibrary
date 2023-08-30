using FluentValidation;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.Exceptions;
using WildwoodLib.Application.UseCase.Entity.Book;
using WildwoodLib.Implementation.Validators;
using static WildwoodLib.Application.UseCase.Entity.Book.Book;

namespace WildwoodLib.Implementation.UseCase.Book
{
    public class EfUpdateBookCommand : UseCaseContext, IUpdateBookCommand
    {
        public EfUpdateBookCommand(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 15;

        public void Execute(UpdateBookDto request)
        {
            var book = Context.Books.Find(request.Id) ?? throw new EntityNotFoundException();
            new CreateBookValidator(Context).ValidateAndThrow(request);

            book.Title = request.Title;
            book.Quantity = request.Quantity;
            book.WriterId = request.WriterId;
            book.CategoryId = request.CategoryId;

            Context.SaveChanges();
        }
    }
}
