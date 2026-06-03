using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.CategoryDtos.CategoryDto
{
    public class CategoryUpdateDto
    {
        public string categoryID { get; set; }
        public string categoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
