using FluentValidation;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.Exceptions;
using WildwoodLib.Application.UseCase.Entity.Checkout;
using WildwoodLib.Implementation.Validators;
using static WildwoodLib.Application.UseCase.Entity.Checkout.Checkout;

namespace WildwoodLib.Implementation.UseCase.Checkout
{
    public class EfCreateCheckoutCommand : UseCaseContext, ICreateCheckoutCommand
    {
        public EfCreateCheckoutCommand(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 22;

        public void Execute(CreateCheckoutDto request)
        {
            var activeQuant = Context.Checkouts.Count(x => x.BookId == request.BookId && x.WasReturned == false);
            var curBook = Context.Books.Find(request.BookId) ?? throw new EntityNotFoundException();
            if (curBook.Quantity <= activeQuant) throw new CheckoutQuantityException();

            new CreateCheckoutValidator(Context).ValidateAndThrow(request);

            var newCheckout = new Domain.Entites.Checkout
            {
                UserId = request.UserId,
                BookId = request.BookId,
                DateStart = request.DateStart,
                DateEnd = request.DateEnd,
                WasReturned = request.WasReturned,
            };

            Context.Checkouts.Add(newCheckout);
            Context.SaveChanges();
        }
    }
}
