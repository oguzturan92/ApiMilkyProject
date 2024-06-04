using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milky.Dto.ProductDtos
{
    public class ProductResultDto
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductImage { get; set; }
        public string ProductPrice { get; set; }
        public string ProductSalePrice { get; set; }
        public string ProductLink { get; set; }
    }
}