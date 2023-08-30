using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildwoodLib.Domain.Entites
{
    public class Checkout : Entity
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public required DateTime DateStart { get; set; }
        public required DateTime DateEnd { get; set; }
        public required bool WasReturned { get; set; } = false;

        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}
