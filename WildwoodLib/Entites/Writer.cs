using System.ComponentModel.DataAnnotations;

namespace WildwoodLib.Domain.Entites
{
    public class Writer : Entity
    {
        [Required, MaxLength(256)]
        public required string FirstName { get; set; }
        [Required, MaxLength(256)]
        public required string LastName { get; set; }
        [MaxLength(256)]
        public string? CountryOfBirth { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
