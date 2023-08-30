using FluentValidation;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.Exceptions;
using WildwoodLib.Application.UseCase.Entity.Category;
using WildwoodLib.Implementation.Validators;
using static WildwoodLib.Application.UseCase.Entity.Category.Category;

namespace WildwoodLib.Implementation.UseCase.Category
{
    public class EfUpdateCategoryCommand : UseCaseContext, IUpdateCategoryCommand
    {
        public EfUpdateCategoryCommand(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 19;

        public void Execute(UpdateCategoryDto request)
        {
            var category = Context.Categories.Find(request.CategoryId) ?? throw new EntityNotFoundException();
            new CreateCategoryValidator(Context).ValidateAndThrow(request);

            category.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
