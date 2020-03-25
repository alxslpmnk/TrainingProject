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
        }
    }
  
}
    
