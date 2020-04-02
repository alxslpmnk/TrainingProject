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
            modelBuilder.Entity<User>()
                .HasKey(x => x.id_user);
            modelBuilder.Entity<User>().Property(x => x.id_user).ValueGeneratedOnAdd();
            modelBuilder.Entity<Performer>().HasMany(x => x.Reviews).WithOne().HasForeignKey(x => x.id_review);
            modelBuilder.Entity<Order>().HasKey(x => x.id_order);
            modelBuilder.Entity<Order>().Property(x => x.id_order).ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>().HasOne<Categories>().WithMany().HasForeignKey(c => c.id_category);
            modelBuilder.Entity<Order>().HasOne<User>().WithMany().HasForeignKey(c => c.id_user);
            modelBuilder.Entity<Categories>().HasKey(x => x.id_category);
            modelBuilder.Entity<PerformerReview>().HasKey(x => x.id_review);
            modelBuilder.Entity<Status>().HasKey(x => x.id_status);
            modelBuilder.Entity<UserType>().HasKey(x => x.id_userType);
            modelBuilder.Entity<Performer>().HasKey(x => x.id_perf);
        }
    }
  
}
    
