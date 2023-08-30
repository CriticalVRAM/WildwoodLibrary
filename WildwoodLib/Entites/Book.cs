using System.ComponentModel.DataAnnotations;

namespace WildwoodLib.Domain.Entites
{
    public class Book : Entity
    {
        [Required, MaxLength(256)]
        public required string Title { get; set; }
        [Required]
        public required int Quantity { get; set; }
        [Required]
        public int WriterId { get; set; }
        [Required]
        public int CategoryId { get; set; }


        public virtual Writer Writer { get; set; }
        public virtual ICollection<Checkout> Checkouts { get; set; }
        public virtual Category Category { get; set; }
    }
}
