using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTOs
{
    public class ProductDto : BaseModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
