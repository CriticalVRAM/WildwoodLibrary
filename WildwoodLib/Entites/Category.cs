using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildwoodLib.Domain.Entites
{
    public class Category : Entity
    {
        [Required, MaxLength(256)]
        public required string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
