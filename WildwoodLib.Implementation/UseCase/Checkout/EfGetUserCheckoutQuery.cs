using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCase.Entity;
using WildwoodLib.Application.UseCase.Entity.Checkout;
using WildwoodLib.Domain.Entites;
using static WildwoodLib.Application.UseCase.Entity.Checkout.Checkout;

namespace WildwoodLib.Implementation.UseCase.Checkout
{
    public class EfGetUserCheckoutQuery : UseCaseContext, IGetUserCheckoutQuery
    {
        private IAppUser _user { get; set; }
        public EfGetUserCheckoutQuery(WildwoodLibContext context, IAppUser user) : base(context)
        {
            _user = user;
        }

        public int Id => 25;

        public PagedResponse<CheckoutDto> Execute(UserCheckoutSearchDto search)
        {
            var result = Context.Checkouts.AsQueryable();

            result = result.Where(x => x.UserId == _user.Id);
            if (search.BookId != null) result = result.Where(x => x.BookId == search.BookId);
            if (search.DateStart != null) result = result.Where(x => x.DateStart == search.DateStart);
            if (search.DateEnd != null) result = result.Where(x => x.DateEnd == search.DateEnd);
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
