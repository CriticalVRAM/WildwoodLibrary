using System.ComponentModel.DataAnnotations;

namespace WildwoodLib.Domain.Entites
{
    public class User : Entity
    {
        [Required, MaxLength(256)]
        public required string Username { get; set; }
        [Required, MaxLength(256)]
        public required string FirstName { get; set; }
        [Required, MaxLength(256)]
        public required string LastName { get; set; }
        [Required, MaxLength(512)]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        public virtual ICollection<UserUseCase> UseCases { get; set;}
        public virtual ICollection<Checkout> Checkouts { get; set; }
    }
}
