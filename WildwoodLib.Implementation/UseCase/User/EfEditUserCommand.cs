using FluentValidation;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.Exceptions;
using WildwoodLib.Application.UseCases.Entity.User;
using WildwoodLib.Implementation.Validators;

namespace WildwoodLib.Implementation.UseCase.User
{
    public class EfEditUserCommand : UseCaseContext, IEditUserCommand
    {
        public EfEditUserCommand(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 4;

        public void Execute(EditUserDto request)
        {
            new EditUserValidator(Context).ValidateAndThrow(request);
            var user = Context.Users.Find(request.Id) ?? throw new EntityNotFoundException();
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Username = request.Username;
            user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            Context.SaveChanges();
        }
    }
}
