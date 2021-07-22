using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    public class ProductCategory : BaseModel
    {
        public int ProductId { get; set; }


        [JsonIgnore]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
