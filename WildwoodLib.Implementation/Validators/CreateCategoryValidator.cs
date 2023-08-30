using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildwoddLib.DataAccess;
using WildwoodLib.Application.UseCase.Entity.Category;

namespace WildwoodLib.Implementation.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        private WildwoodLibContext _context;
        public CreateCategoryValidator(WildwoodLibContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required.");
        }
    }
}
