using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Context
{
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<ECommerceDbContext>
    {
        public ECommerceDbContext CreateDbContext(string[] args)
        {
            string connectionStr = "Data Source=WIN-401QH6I8IG7;Initial Catalog=ECommerce1;Integrated Security=True;";

            var builder = new DbContextOptionsBuilder<ECommerceDbContext>();
            builder.UseSqlServer(connectionStr);

            return new ECommerceDbContext(builder.Options);
        }
    }
}
