using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    public class Category : BaseModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}
