namespace WildwoodLib.Application.Exceptions
{
    public class EntityExistsException : Exception
    {
        public EntityExistsException()
    : base($"The requested entity already exists.")
        {

        }
    }
}
