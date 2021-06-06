using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FileUpload.Models
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Product>().HasData(new Product { Id = 1,Name="Plane",Description="Good",Price=234.45f }) ;
            base.OnModelCreating(builder);
        }
        public DbSet<Product> Products { get; set; }
    }
}
