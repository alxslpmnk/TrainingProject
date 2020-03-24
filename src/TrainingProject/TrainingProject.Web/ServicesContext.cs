using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingProject.Data;
using TrainingProject.Data.Models;

namespace TrainingProject.Web
{
    public class ServicesContext : DbContext, IServicesContext
    {
        public ServicesContext(DbContextOptions<ServicesContext> options)
            : base(options) { } 
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<PerformerReview> PerformerReviews { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Status> Statuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Product>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>()
                .Property(x => x.SaleFrom)
                .HasConversion(x => x, x => x.HasValue ? DateTime.SpecifyKind(x.Value, DateTimeKind.Utc) : x);
            modelBuilder.Entity<Product>()
                .HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Product>()
                .HasMany(x => x.Reviews)
                .WithOne()
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<ProductReview>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<ProductReview>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
  
}
    
