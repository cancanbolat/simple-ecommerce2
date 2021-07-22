using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Entities;
using E_Commerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repositories
{
    public class ProductPriceRepository : GenericRepository<ProductPrice>, IProductPriceRepository
    {
        public ProductPriceRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
