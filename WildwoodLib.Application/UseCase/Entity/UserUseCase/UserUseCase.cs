namespace WildwoodLib.Application.UseCase.Entity.UserUseCase
{
    public class UserUseCase
    {
        public interface IGetUserUseCaseQuery : IQuery<UserUseCaseSearchDto, PagedResponse<UserUseCaseDto>> { }
        public interface ICreateUserUseCaseCommand : ICommand<CreateUserUseCaseDto> { }
        public interface IDeleteUserUseCaseCommand : ICommand<DeleteUserUseCaseDto> { }
    }
}
