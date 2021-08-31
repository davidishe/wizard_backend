using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace Infrastructure.Data.Config
{
  public class ItemConfiguration : IEntityTypeConfiguration<Item>
  {
    public void Configure(EntityTypeBuilder<Item> builder)
    {
      builder.Property(p => p.Id).IsRequired();
      builder.Property(p => p.MessageText).IsRequired();
      builder.Property(p => p.JobId).IsRequired();
      builder.Property(p => p.AuthorId).IsRequired();
      builder.Property(p => p.ChatId).IsRequired();
      builder.Property(p => p.EnrolledDate).IsRequired();
      builder.HasOne(b => b.ItemType).WithMany().HasForeignKey(p => p.ItemTypeId);

    }
  }
}