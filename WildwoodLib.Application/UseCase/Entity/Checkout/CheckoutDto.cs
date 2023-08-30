using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildwoodLib.Application.UseCase.Entity.Checkout
{
    public class CheckoutDto
    {
        public required int Id { get; set; }
        public required int UserId { get; set; }
        public required int BookId { get; set; }
        public required DateTime DateStart { get; set; }
        public required DateTime DateEnd { get; set; }
        public required bool WasReturned { get; set; }
    }
    public class CheckoutSearchDto : PagedSearch
    {
        public int? UserId { get; set; }
        public int? BookId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? WasReturned { get; set; }
    }
    public class UserCheckoutSearchDto : PagedSearch
    {
        public int? BookId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? WasReturned { get; set; }
    }
    public class CreateCheckoutDto
    {
        public required int UserId { get; set; }
        public required int BookId { get; set; }
        public required DateTime DateStart { get; set; }
        public required DateTime DateEnd { get; set; }
        public bool WasReturned { get; set; }
    }
    public class UpdateCheckoutDto : CreateCheckoutDto
    {

    }
    public class DeleteCheckoutDto
    {
        public required int UserId { get; set; }
        public required int BookId { get; set; }
    }
}
