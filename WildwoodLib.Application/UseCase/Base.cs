using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildwoodLib.Application.UseCase
{
    public interface IUseCase
    {
        public int Id { get; }
    }

    public interface IQuery<TRequest, TResult> : IUseCase
    {
        TResult Execute(TRequest search);
    }

    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }
}
