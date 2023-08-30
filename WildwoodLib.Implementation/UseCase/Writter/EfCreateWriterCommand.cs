using FluentValidation;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCase.Entity.Writter;
using WildwoodLib.Implementation.Validators;
using static WildwoodLib.Application.UseCase.Entity.Writter.Writer;

namespace WildwoodLib.Implementation.UseCase.Writter
{
    public class EfCreateWriterCommand : UseCaseContext, ICreateWriterCommand
    {
        public EfCreateWriterCommand(WildwoodLibContext context) : base(context)
        {
        }

        public int Id => 6;

        public void Execute(CreateWriterDto request)
        {
            new CreateWriterValidator(Context).ValidateAndThrow(request);

            var newWriter = new Domain.Entites.Writer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                CountryOfBirth = request.CountryOfBirth
            };
            Context.Writers.Add(newWriter);
            Context.SaveChanges();
        }
    }
}
