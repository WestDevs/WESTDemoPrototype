using Microsoft.EntityFrameworkCore;
using WESTDemo.Domain.Models;
using System.Linq;

namespace WESTDemo.Infrastracture.Context
{
  public class UsersContext : DbContext
  {
    public UsersContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Learner> Learners { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<Centre> Centres { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<UserType> UserTypes { get; set; }
    public DbSet<LearnerStatus> LearnerStatuses { get; set; }
    // public DbSet<LearnerGroup> LearnerGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      foreach (var property in modelBuilder.Model.GetEntityTypes()
          .SelectMany(e => e.GetProperties()
              .Where(p => p.ClrType == typeof(string))))
        property.SetColumnType("varchar(150)");

      modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersContext).Assembly);

      foreach (var relationship in modelBuilder.Model.GetEntityTypes()
          .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

      base.OnModelCreating(modelBuilder);
    }
  }
}
