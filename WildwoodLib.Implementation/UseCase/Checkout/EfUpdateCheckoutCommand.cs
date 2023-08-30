using FluentValidation;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.Exceptions;
using WildwoodLib.Application.UseCase.Entity.Checkout;
using WildwoodLib.Implementation.Validators;
using static WildwoodLib.Application.UseCase.Entity.Checkout.Checkout;

namespace WildwoodLib.Implementation.UseCase.Checkout
{
    public class EfUpdateCheckoutCommand : UseCaseContext, IUpdateCheckoutCommand
    {
        public EfUpdateCheckoutCommand(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 23;

        public void Execute(UpdateCheckoutDto request)
        {
            var checkouts = Context.Checkouts.Where(x => x.UserId == request.UserId && x.BookId == request.BookId);
            if (checkouts == null) throw new EntityNotFoundException();

            var activeQuant = Context.Checkouts.Count(x => x.BookId == request.BookId && x.WasReturned == false);
            var curBook = Context.Books.Find(request.BookId) ?? throw new EntityNotFoundException();
            if (curBook.Quantity < activeQuant) throw new CheckoutQuantityException();
            new CreateCheckoutValidator(Context).ValidateAndThrow(request);

            var entity = checkouts.First();

            entity.UserId = request.UserId;
            entity.BookId = request.BookId;
            entity.DateStart = request.DateStart;
            entity.DateEnd = request.DateEnd;
            entity.WasReturned = request.WasReturned;

            Context.SaveChanges();
        }
    }
}
