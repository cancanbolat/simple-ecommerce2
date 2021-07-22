using E_Commerce.Domain.Common;
using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTOs
{
    public class ProductDetailDto : BaseModel
    {
        public string Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string CategorySlug { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public List<ProductPriceDto> Prices { get; set; } = new List<ProductPriceDto>();
    }
}
