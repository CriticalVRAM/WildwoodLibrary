using WildwoddLib.DataAccess;
using WildwoodLib.Application.Exceptions;
using static WildwoodLib.Application.UseCase.Entity.Category.Category;

namespace WildwoodLib.Implementation.UseCase.Category
{
    public class EfDeleteCategoryCommand : UseCaseContext, IDeleteCategoryCommand
    {
        public EfDeleteCategoryCommand(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 20;

        public void Execute(int request)
        {
            var entity = Context.Categories.Find(request) ?? throw new EntityNotFoundException();
            if (entity.IsDeleted == null) entity.IsDeleted = DateTime.UtcNow;
            else if (entity.IsDeleted != null) entity.IsDeleted = null;
            Context.SaveChanges();
        }
    }
}
