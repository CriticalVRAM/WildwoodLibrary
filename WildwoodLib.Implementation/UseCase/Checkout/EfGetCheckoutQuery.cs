using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCase.Entity;
using WildwoodLib.Application.UseCase.Entity.Checkout;
using static WildwoodLib.Application.UseCase.Entity.Checkout.Checkout;

namespace WildwoodLib.Implementation.UseCase.Checkout
{
    public class EfGetCheckoutQuery : UseCaseContext, IGetCheckoutQuery
    {
        public EfGetCheckoutQuery(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 21;

        public PagedResponse<CheckoutDto> Execute(CheckoutSearchDto search)
        {
            var result = Context.Checkouts.AsQueryable();

            if (search.UserId != null) result = result.Where(x => x.UserId == search.UserId);
            if (search.BookId != null)  result = result.Where(x => x.BookId == search.BookId);
            if (search.DateStart != null) result = result.Where(x => x.DateStart == search.DateStart);
            if (search.DateEnd != null)  result = result.Where(x => x.DateEnd == search.DateEnd);
            if (search.WasReturned != null) result = result.Where(x => x.WasReturned == search.WasReturned);

            return result.ToPagedResponse(search, x => new CheckoutDto
            {
                Id = x.Id,
                UserId = x.UserId,
                BookId = x.BookId,
                DateStart = x.DateStart,
                DateEnd = x.DateEnd,
                WasReturned = x.WasReturned
            });
        }
    }
}
