using WildwoddLib.DataAccess;
using WildwoodLib.Application.Exceptions;
using WildwoodLib.Application.UseCase.Entity.Checkout;
using static WildwoodLib.Application.UseCase.Entity.Checkout.Checkout;

namespace WildwoodLib.Implementation.UseCase.Checkout
{
    public class EfDeleteCheckoutCommand : UseCaseContext, IDeleteCheckoutCommand
    {
        public EfDeleteCheckoutCommand(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 24;

        public void Execute(DeleteCheckoutDto request)
        {
            var checkouts = Context.Checkouts.Where(x => x.UserId == request.UserId && x.BookId == request.BookId);
            if (checkouts.Any() == false) throw new EntityNotFoundException();

            var entity = checkouts.First();
            if (entity.WasReturned) entity.WasReturned = false;
            else if (!entity.WasReturned) entity.WasReturned = true;
            Context.SaveChanges();
        }
    }
}
