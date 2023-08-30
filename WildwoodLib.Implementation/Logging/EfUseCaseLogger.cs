using WildwoddLib.DataAccess;
using WildwoodLib.Application;
using WildwoodLib.Implementation.UseCase;

namespace WildwoodLib.Implementation.Logging
{
    public class EfUseCaseLogger : UseCaseContext, IUseCaseLogger
    {
        public EfUseCaseLogger(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 5;

        public IEnumerable<UseCaseLog> GetLogs(UseCaseLogSearch search)
        {
            try
            {
                var query = Context.UseCaseLogs.AsQueryable();
                if (search.UseCaseID == null && search.UserID == null && search.DateFrom == null && search.DateTo == null)
                {
                    return query.Select(x => new UseCaseLog
                    {
                        UseCaseId = x.UseCaseId,
                        UserId = x.UserId,
                        ExecutionDateTime = x.ExecutionDateTime,
                        Data = x.Data,
                        IsAuthorized = x.IsAuthorized
                    }).ToList();
                }
                if (search.UseCaseID != null) query = query.Where(x => x.UseCaseId == search.UseCaseID);
                if (search.UserID != null) query = query.Where(x => x.UserId == search.UserID);
                // 20-aug : 19 aug > 20 aug FALSE ; 21 aug > 20 aug TRUE
                if (search.DateFrom != null) query = query.Where(x => x.ExecutionDateTime >= search.DateFrom);
                // 20-aug : 21 aug < 20 aug FALSE ; 19 aug < 20 aug TRUE
                if (search.DateTo != null) query = query.Where(x => x.ExecutionDateTime <= search.DateTo);
                return (IEnumerable<UseCaseLog>)query.ToPagedResponse(search, x => new UseCaseLog
                {
                    UseCaseId = x.UseCaseId,
                    UserId = x.UserId,
                    ExecutionDateTime = x.ExecutionDateTime,
                    Data = x.Data,
                    IsAuthorized = x.IsAuthorized
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Log(UseCaseLog log)
        {
            try
            {
                var newLog = new Domain.Entites.UseCaseLog
                {
                    UseCaseId = log.UseCaseId,
                    UserId = log.UserId,
                    ExecutionDateTime = log.ExecutionDateTime,
                    Data = log.Data,
                    IsAuthorized = log.IsAuthorized
                };
                Context.UseCaseLogs.Add(newLog);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
