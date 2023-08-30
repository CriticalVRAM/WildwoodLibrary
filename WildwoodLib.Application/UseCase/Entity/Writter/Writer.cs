using WildwoodLib.Application.UseCases.Entity.User;

namespace WildwoodLib.Application.UseCase.Entity.Writter
{
    public class Writer
    {
        public interface IGetWritersQuery : IQuery<BasePagedSearch, PagedResponse<WriterDto>> { }
        public interface ICreateWriterCommand : ICommand<CreateWriterDto> { }
        public interface IEditWriterCommand : ICommand<CreateWriterDto> { }
        public interface IDeleteWriterCommand : ICommand<int> { }
    }
}
