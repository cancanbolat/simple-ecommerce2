using E_Commerce.Domain.Common;
using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.DTOs
{
    public class CartItemDto : BaseModel
    {
        public string UserId { get; set; }
        public int EditionId { get; set; }
        public string EditionTitle { get; set; }

        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        public decimal Price { get; set; }
        
        public Int16 Quantity { get; set; }
    }
}
