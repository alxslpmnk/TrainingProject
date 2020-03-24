using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingProject.Data.Models;

namespace TrainingProject.Data
{
    public interface IServicesContext
    {
        DbSet<User> Users { get; set; }
        DbSet<UserType> UserTypes { get; set; }
        DbSet<Performer> Performers { get; set; }
        DbSet<PerformerReview> PerformerReviews { get; set; }
        DbSet<Categories> Categories { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Status> Statuses { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);


    }
}
