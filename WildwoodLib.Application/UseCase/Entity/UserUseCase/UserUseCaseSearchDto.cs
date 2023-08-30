namespace WildwoodLib.Application.UseCase.Entity.UserUseCase
{
    public class UserUseCaseSearchDto : PagedSearch
    {
        public int? UserId { get; set; }
        public int? UseCaseId { get; set; }
    }
    public class UserUseCaseDto
    {
        public int? UserId { get; set; }
        public int? UseCaseId { get; set; }
    }

    public class CreateUserUseCaseDto
    {
        public required int UserId { get; set; }
        public required int UseCaseId { get; set; }
    }
    public class  DeleteUserUseCaseDto
    {
        public required int UserId { get; set; }
        public required int UseCaseId { get; set; }
    }
}
