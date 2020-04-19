using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingProject.Data;
using TrainingProject.Data.Models;

namespace TrainingProject.Web
{
    public class AppContext : DbContext, IAppContext
    {
        public AppContext(DbContextOptions<AppContext> options)
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
                .HasKey(x => x.IdUser);
            modelBuilder.Entity<User>().Property(x => x.IdUser).ValueGeneratedOnAdd();
            modelBuilder.Entity<Performer>().HasMany(x => x.Reviews).WithOne().HasForeignKey(x => x.IdReview);
            modelBuilder.Entity<Order>().HasKey(x => x.IdOrder);
            modelBuilder.Entity<Order>().Property(x => x.IdOrder).ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>().HasOne<Categories>().WithMany().HasForeignKey(c => c.IdCategory);
            modelBuilder.Entity<Order>().HasOne<User>().WithMany().HasForeignKey(c => c.IdUser);
            modelBuilder.Entity<Categories>().HasKey(x => x.IdCategory);
            modelBuilder.Entity<PerformerReview>().HasKey(x => x.IdReview);
            modelBuilder.Entity<Status>().HasKey(x => x.IdStatus);
            modelBuilder.Entity<UserType>().HasKey(x => x.IdUserType);
            modelBuilder.Entity<Performer>().HasKey(x => x.IdPerformer);
        }
    }
  
}
    
