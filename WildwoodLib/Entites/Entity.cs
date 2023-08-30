using System.ComponentModel;

namespace WildwoodLib.Domain.Entites
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime? IsDeleted { get; set; }
    }
}