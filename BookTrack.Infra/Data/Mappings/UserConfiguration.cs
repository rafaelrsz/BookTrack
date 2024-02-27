using BookTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTrack.Infra.Data.Mappings;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Name).HasMaxLength(255);

    builder.Property(x => x.Password).HasMaxLength(64);

    builder.Property(x => x.Email).HasMaxLength(64);

    builder.Property(x => x.Email).HasMaxLength(255);
    builder.HasIndex(x => x.Email).IsUnique();
  }
}
