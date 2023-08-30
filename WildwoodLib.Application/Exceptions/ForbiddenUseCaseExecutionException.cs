namespace WildwoodLib.Application.Exceptions
{
    public class ForbiddenUseCaseExecutionException : Exception
    {
        public ForbiddenUseCaseExecutionException(int useCase, string user) :
            base($"User {user} has tried to execute {useCase} without being authorized to do so.")
        {

        }
    }
}
