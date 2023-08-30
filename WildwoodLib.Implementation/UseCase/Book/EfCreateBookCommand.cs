using FluentValidation;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCase.Entity.Book;
using WildwoodLib.Domain.Entites;
using WildwoodLib.Implementation.Validators;
using static WildwoodLib.Application.UseCase.Entity.Book.Book;

namespace WildwoodLib.Implementation.UseCase.Book
{
    public class EfCreateBookCommand : UseCaseContext, ICreateBookCommand
    {
        public EfCreateBookCommand(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 14;

        public void Execute(CreateBookDto request)
        {
            new CreateBookValidator(Context).ValidateAndThrow(request);

            var newBook = new Domain.Entites.Book
            {
                Title = request.Title,
                Quantity = request.Quantity,
                WriterId = request.WriterId,
                CategoryId = request.CategoryId
            };
            Context.Books.Add(newBook);
            Context.SaveChanges();
        }
    }
}
