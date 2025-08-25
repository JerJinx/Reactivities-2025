using Microsoft.EntityFrameworkCore;
using Reactivities.Domain.Entities;

namespace Reactivities.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Activity> Activities { get; set; }
}
