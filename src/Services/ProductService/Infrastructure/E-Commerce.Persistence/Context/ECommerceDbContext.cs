using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Context
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Keys
            modelBuilder.Entity<Category>().HasKey(k => k.Id).HasName("CategoryId");
            modelBuilder.Entity<Product>().HasKey(k => k.Id).HasName("ProductId");
            modelBuilder.Entity<ProductCategory>().HasKey(pc => new { pc.Id, pc.ProductId, pc.CategoryId });
            modelBuilder.Entity<ProductPrice>().HasKey(pv => new { pv.Id, pv.ProductId, pv.EditionId });


            //Datas
            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 256925260,
                        Number = DateTime.UtcNow.ToFileTime().ToString(),
                        Title = "SAMSUNG Galaxy S21+",
                        Slug = "samsung-galaxy-s21",
                        Description = "Smartphone Pro-Grade Camera 8K Video 12MP High Res, Phantom Black",
                        Image = "https://i.hizliresim.com/3xgesny.jpg"
                    },
                    new Product
                    {
                        Id = 256925261,
                        Number = DateTime.UtcNow.ToFileTime().ToString(),
                        Title = "Samsung Galaxy S10",
                        Slug = "samsung-galaxy-s10",
                        Description = "Factory Unlocked Android Cell Phone",
                        Image = "https://i.hizliresim.com/3bqzb8v.jpg"
                    },
                    new Product
                    {
                        Id = 256925262,
                        Number = DateTime.UtcNow.ToFileTime().ToString(),
                        Title = "IPhone 12",
                        Slug = "iphone-12",
                        Description = "4 GB RAM",
                        Image = "https://i.hizliresim.com/b26olh0.jpg"
                    },
                    new Product
                    {
                        Id = 256925263,
                        Number = DateTime.UtcNow.ToFileTime().ToString(),
                        Title = "IPhone SE",
                        Slug = "iphone-se",
                        Description = "3 GB RAM",
                        Image = "https://i.hizliresim.com/1vo7jtv.jpg"
                    },
                    new Product
                    {
                        Id = 256925264,
                        Number = DateTime.UtcNow.ToFileTime().ToString(),
                        Title = "Xiaomi Mi 11",
                        Slug = "xiaomi-mi-11",
                        Description = "Ekran Boyutu: 6.81 inç İşletim Sistemi: Android 11 Ram: 8 GB Batarya Kapasitesi: 4600 mAH",
                        Image = "https://i.hizliresim.com/q310mrs.jpg"
                    },
                    new Product
                    {
                        Id = 256925265,
                        Number = DateTime.UtcNow.ToFileTime().ToString(),
                        Title = "Xiaomi Redmi Note 10",
                        Slug = "xiaomi-redmi-note-10",
                        Description = "4GB RAM | GSM LTE Factory Unlocked Smartphone | International Model (Onyx Gray)",
                        Image = "https://i.hizliresim.com/ilub0c4.jpg"
                    }
                );

            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 556925214, Title = "Samsung", Slug = "samsung" },
               new Category { Id = 656925224, Title = "Xiaomi", Slug = "xiaomi" },
               new Category { Id = 756925234, Title = "Apple", Slug = "apple" }
           );

            modelBuilder.Entity<ProductCategory>().HasData(
              new ProductCategory { CategoryId = 556925214, Id = 156925211, ProductId = 256925260 },
              new ProductCategory { CategoryId = 556925214, Id = 156925212, ProductId = 256925261 },
              new ProductCategory { CategoryId = 656925224, Id = 156925213, ProductId = 256925262 },
              new ProductCategory { CategoryId = 656925224, Id = 156925214, ProductId = 256925263 },
              new ProductCategory { CategoryId = 756925234, Id = 156925215, ProductId = 256925264 },
              new ProductCategory { CategoryId = 756925234, Id = 156925216, ProductId = 256925265 }
              );

            modelBuilder.Entity<Edition>().HasData(
                 new Edition { Id = 256925214, Title = "32 GB" },
                 new Edition { Id = 256925224, Title = "64 GB" },
                 new Edition { Id = 256925234, Title = "128 GB" },
                 new Edition { Id = 256925244, Title = "256 GB" }
                );

            modelBuilder.Entity<ProductPrice>().HasData(
                new ProductPrice { Id = 156925211, ProductId = 256925260, EditionId = 256925214, Price = 770.45m },
                new ProductPrice { Id = 156925212, ProductId = 256925260, EditionId = 256925224, Price = 1770.45m },
                new ProductPrice { Id = 156925213, ProductId = 256925260, EditionId = 256925234, Price = 2770.45m },

                new ProductPrice { Id = 156925213, ProductId = 256925261, EditionId = 256925214, Price = 1060.45m },
                new ProductPrice { Id = 156925214, ProductId = 256925261, EditionId = 256925224, Price = 2060.45m },
                new ProductPrice { Id = 156925216, ProductId = 256925261, EditionId = 256925234, Price = 3060.45m },
                new ProductPrice { Id = 156925217, ProductId = 256925261, EditionId = 256925244, Price = 4060.45m },

                new ProductPrice { Id = 156925218, ProductId = 256925262, EditionId = 256925214, Price = 1750.45m },
                new ProductPrice { Id = 156925219, ProductId = 256925262, EditionId = 256925224, Price = 2750.45m },
                new ProductPrice { Id = 156925220, ProductId = 256925262, EditionId = 256925234, Price = 2950.45m },

                new ProductPrice { Id = 156925221, ProductId = 256925263, EditionId = 256925214, Price = 3240.45m },
                new ProductPrice { Id = 156925222, ProductId = 256925263, EditionId = 256925224, Price = 4240.45m },
                new ProductPrice { Id = 156925223, ProductId = 256925263, EditionId = 256925234, Price = 5240.45m },
                new ProductPrice { Id = 156925224, ProductId = 256925263, EditionId = 256925244, Price = 6240.45m },

                new ProductPrice { Id = 156925225, ProductId = 256925264, EditionId = 256925214, Price = 3240.45m },
                new ProductPrice { Id = 156925226, ProductId = 256925264, EditionId = 256925224, Price = 4240.45m },
                new ProductPrice { Id = 156925227, ProductId = 256925264, EditionId = 256925234, Price = 5240.45m },
                new ProductPrice { Id = 156925228, ProductId = 256925264, EditionId = 256925244, Price = 6240.45m },

                new ProductPrice { Id = 156925229, ProductId = 256925265, EditionId = 256925214, Price = 4240.45m },
                new ProductPrice { Id = 156925230, ProductId = 256925265, EditionId = 256925224, Price = 5240.45m },
                new ProductPrice { Id = 156925231, ProductId = 256925265, EditionId = 256925234, Price = 7240.45m }
                );
        }
    }
}
