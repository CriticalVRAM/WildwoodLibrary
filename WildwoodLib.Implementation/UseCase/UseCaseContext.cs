using WildwoddLib.DataAccess;

namespace WildwoodLib.Implementation.UseCase
{
    public abstract class UseCaseContext
    {
        public WildwoodLibContext Context { get; set; }
        public UseCaseContext(WildwoodLibContext context) => Context = context;
    }
}
