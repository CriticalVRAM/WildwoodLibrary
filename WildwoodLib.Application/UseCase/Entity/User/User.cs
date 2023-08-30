using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildwoodLib.Application.UseCase;
using WildwoodLib.Application.UseCase.Entity;

namespace WildwoodLib.Application.UseCases.Entity.User
{
    public interface IGetUsersQuery : IQuery<BasePagedSearch, PagedResponse<UserDto>> { }
    public interface ICreateUserCommand : ICommand<CreateUserDto> { }
    public interface IEditUserCommand : ICommand<EditUserDto> { }
    public interface IDeleteUserCommand : ICommand<int> { }
}
