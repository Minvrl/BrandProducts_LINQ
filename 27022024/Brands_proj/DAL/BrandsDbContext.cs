using Brands_proj.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brands_proj.DAL
{
    public class BrandsDbContext:DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= MIMI\\SQLEXPRESS;Database= BrandsDb; Trusted_connection =true");
        }
    }
}
