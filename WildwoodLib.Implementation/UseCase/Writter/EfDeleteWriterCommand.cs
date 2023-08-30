using System.Net;
using System.Web.Http;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.Exceptions;
using static WildwoodLib.Application.UseCase.Entity.Writter.Writer;

namespace WildwoodLib.Implementation.UseCase.Writter
{
    public class EfDeleteWriterCommand : UseCaseContext, IDeleteWriterCommand
    {
        public EfDeleteWriterCommand(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 7;

        public void Execute(int request)
        {
            var writer = Context.Writers.Find(request) ?? throw new EntityNotFoundException();
            if (writer.IsDeleted == null) writer.IsDeleted = DateTime.UtcNow;
            else if (writer.IsDeleted != null) writer.IsDeleted = null;
            Context.SaveChanges();
        }
        
    }
}
