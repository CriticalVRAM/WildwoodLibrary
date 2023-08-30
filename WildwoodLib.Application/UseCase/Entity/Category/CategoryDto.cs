using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildwoodLib.Application.UseCase.Entity.Category
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }

    }
    public class CreateCategoryDto
    {
        public required string Name { get; set; }
    }
    public class UpdateCategoryDto : CreateCategoryDto
    {
        public required int CategoryId { get; set; }
    }
}
