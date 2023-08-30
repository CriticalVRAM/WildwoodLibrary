using FluentValidation;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCase.Entity.Category;
using WildwoodLib.Implementation.Validators;
using static WildwoodLib.Application.UseCase.Entity.Category.Category;

namespace WildwoodLib.Implementation.UseCase.Category
{
    public class EfCreateCategoryCommand : UseCaseContext, ICreateCategoryCommand
    {
        public EfCreateCategoryCommand(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 18;

        public void Execute(CreateCategoryDto request)
        {
            new CreateCategoryValidator(Context).ValidateAndThrow(request);
            var newCat = new Domain.Entites.Category
            {
                Name = request.Name
            };
            Context.Categories.Add(newCat);
            Context.SaveChanges();
        }
    }
}
