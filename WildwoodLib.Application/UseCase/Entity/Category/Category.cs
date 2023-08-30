namespace WildwoodLib.Application.UseCase.Entity.Category
{
    public class Category
    {
        public interface IGetCategoryQuery : IQuery<BasePagedSearch, PagedResponse<CategoryDto>> { }
        public interface ICreateCategoryCommand : ICommand<CreateCategoryDto> { }
        public interface IUpdateCategoryCommand : ICommand<UpdateCategoryDto> { }
        public interface IDeleteCategoryCommand : ICommand<int> { }
    }
}
