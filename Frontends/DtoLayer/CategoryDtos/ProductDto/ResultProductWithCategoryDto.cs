using DtoLayer.CategoryDtos.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.CategoryDtos.ProductDto
{
    public class ResultProductWithCategoryDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImgUrl { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }
        public CategoryResultDto Category { get; set; }
    }
}
