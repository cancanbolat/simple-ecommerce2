using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    public class CartItem : BaseModel
    {
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int EditionId { get; set; }
        public Int16 Quantity { get; set; }
    }
}
