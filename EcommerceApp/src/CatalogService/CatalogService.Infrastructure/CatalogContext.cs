using CatalogService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Infrastructure
{
    public class CatalogContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public CatalogContext(DbContextOptions<CatalogContext> dbContextOptions): base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(p =>
            {
                p.Property(c => c.Name).IsRequired(true).HasColumnType("nvarchar(200)");
                p.Property(c => c.Summary).IsRequired(false).HasColumnType("nvarchar(200)");
                p.Property(c => c.Category).IsRequired(false).HasColumnType("nvarchar(200)");
                p.Property(c => c.Price).IsRequired(true).HasColumnType("decimal(12,2)");
                p.Property(c => c.Description).IsRequired(true).HasColumnType("nvarchar(400)");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
