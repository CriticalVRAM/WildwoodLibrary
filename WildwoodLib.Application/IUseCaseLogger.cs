using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildwoodLib.Application.UseCase.Entity;

namespace WildwoodLib.Application
{
    public interface IUseCaseLogger
    {
        public int Id { get; }
        void Log(UseCaseLog log);
        IEnumerable<UseCaseLog> GetLogs(UseCaseLogSearch search);
    }

    public class UseCaseLogSearch : PagedSearch
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? UseCaseID { get; set; }
        public int? UserID { get; set; }
    }

    public class UseCaseLog
    {
        public int UseCaseId { get; set; }
        public int UserId { get; set; }
        public DateTime ExecutionDateTime { get; set; }
        public string? Data { get; set; }
        public bool IsAuthorized { get; set; }
    }
}
