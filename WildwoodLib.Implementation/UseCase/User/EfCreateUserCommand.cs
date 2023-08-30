using FluentValidation;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCases.Entity.User;
using WildwoodLib.Implementation.Validators;

namespace WildwoodLib.Implementation.UseCase.User
{
    public class EfCreateUserCommand : UseCaseContext, ICreateUserCommand
    {
        public EfCreateUserCommand(WildwoodLibContext context) : base(context)
        {
           
        }

        public int Id => 2;

        public void Execute(CreateUserDto request)
        {
            new CreateUserValidator(Context).ValidateAndThrow(request);

            var newUser = new Domain.Entites.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };
            Context.Users.Add(newUser);
            Context.SaveChanges();
        }
    }
}
