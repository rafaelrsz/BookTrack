using BookTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTrack.Infra.Data.Mappings;
public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
  public void Configure(EntityTypeBuilder<Publisher> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Name).HasMaxLength(255);

    builder.Property(x => x.Phone).HasMaxLength(15);

    builder.Property(x => x.FoundationDate);
  }
}