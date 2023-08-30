using WildwoddLib.DataAccess;
using WildwoodLib.Application.Exceptions;
using static WildwoodLib.Application.UseCase.Entity.Book.Book;

namespace WildwoodLib.Implementation.UseCase.Book
{
    public class EfDeleteBookCommand : UseCaseContext, IDeleteBookCommand
    {
        public EfDeleteBookCommand(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 16;

        public void Execute(int request)
        {
            var entity = Context.Books.Find(request) ?? throw new EntityNotFoundException();
            if (entity.IsDeleted == null) entity.IsDeleted = DateTime.UtcNow;
            else if (entity.IsDeleted != null) entity.IsDeleted = null;
            Context.SaveChanges();
        }
    }
}
