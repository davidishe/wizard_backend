using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Wizard.Infrastructure.Database
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options)
      : base(options)
    {
      Database.EnsureCreated();
    }

    public DbSet<Link> Links { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      base.OnModelCreating(modelBuilder);
      // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

  }

}
