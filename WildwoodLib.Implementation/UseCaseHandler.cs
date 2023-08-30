using Newtonsoft.Json;
using WildwoodLib.Application;
using WildwoodLib.Application.Exceptions;
using WildwoodLib.Application.UseCase;
using WildwoodLib.Domain.Entites;

namespace WildwoodLib.Implementation
{
    public class UseCaseHandler
    {
        private IExceptionLogger _logger { get; set; }
        private IAppUser _user { get; set; }
        private IUseCaseLogger _useCaseLogger { get; set; }

        public UseCaseHandler(IExceptionLogger logger, IAppUser user, IUseCaseLogger useCaseLogger)
        {
            _logger = logger;
            _user = user;
            _useCaseLogger = useCaseLogger;
        }

        public void HandleCommand<TRequest> (ICommand<TRequest> usecase, TRequest request)
        {
            try
            {
                HandleLoggingAndAuth(usecase, request);
                usecase.Execute(request);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }
        public TResult HandleQuery<TRequest, TResult>(IQuery<TRequest, TResult> usecase, TRequest request)
        {
            try
            {
                HandleLoggingAndAuth(usecase, request);
                return usecase.Execute(request);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }
        private void HandleLoggingAndAuth<TRequest>(IUseCase useCase, TRequest data)
        {
            var isAuthorized = _user.UseCaseIds.Contains(useCase.Id);

            var log = new Application.UseCaseLog
            {
                UseCaseId = useCase.Id,
                UserId = _user.Id,
                ExecutionDateTime = DateTime.UtcNow,
                Data = JsonConvert.SerializeObject(data),
                IsAuthorized = isAuthorized
            };
            _useCaseLogger.Log(log);

            if (!isAuthorized)
            {
                throw new ForbiddenUseCaseExecutionException(useCase.Id, _user.Identity);
            }
        }
    }
}
