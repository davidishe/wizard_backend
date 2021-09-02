using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Contexts
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<BankOffice> BankOffices { get; set; }
    public DbSet<ItemType> ItemTypes { get; set; }
    public DbSet<ItemSubType> ItemSubTypes { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<MemberItem> MemberItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      modelBuilder.Entity<MemberItem>()
          .HasKey(cs => new { cs.ItemId, cs.MemberId });

      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

  }

}
