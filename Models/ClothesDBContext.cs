using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HLTClothes.Models
{
    public class ClothesDBContext : DbContext
    {
        public ClothesDBContext() : base("MyCS") { }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
    }
}