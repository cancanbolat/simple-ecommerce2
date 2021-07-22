using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    public class ProductPrice : BaseModel
    {
        public int ProductId { get; set; }

        public Edition Edition { get; set; }
        public int EditionId { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
