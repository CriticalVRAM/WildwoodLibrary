using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildwoodLib.Domain.Entites
{
    public class UseCaseLog
    {
        public int UseCaseLogId { get; set; }
        public required int UseCaseId { get; set; }
        public required int UserId { get; set; }
        public required DateTime ExecutionDateTime { get; set; }
        public required string Data { get; set; }
        public required bool IsAuthorized { get; set; }
    }
}
