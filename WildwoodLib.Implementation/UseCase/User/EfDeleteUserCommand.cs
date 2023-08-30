using Azure.Core;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.Exceptions;
using WildwoodLib.Application.UseCases.Entity.User;

namespace WildwoodLib.Implementation.UseCase.User
{
    public class EfDeleteUserCommand : UseCaseContext, IDeleteUserCommand
    {
        public EfDeleteUserCommand(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 3;

        public void Execute(int request)
        {
            var entity = Context.Users.Find(request) ?? throw new EntityNotFoundException();
            if (entity.IsDeleted == null) entity.IsDeleted = DateTime.UtcNow;
            else if (entity.IsDeleted != null) entity.IsDeleted = null;
            Context.SaveChanges();
        }
        
    }
}
