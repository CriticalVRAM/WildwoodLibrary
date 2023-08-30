using System.ComponentModel.DataAnnotations;

namespace WildwoodLib.Domain.Entites
{
    public class UserUseCase
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }
        public DateTime? IsDeleted { get; set; }
        public virtual User User { get; set; }
    }
}
