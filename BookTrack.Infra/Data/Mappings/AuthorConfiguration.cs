using BookTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace BookTrack.Infra.Data.Mappings;
public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
  public void Configure(EntityTypeBuilder<Author> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Name)
           .HasMaxLength(255);  
    
    builder.Property(x => x.Nationality)
           .HasMaxLength(2);  
    
    builder.Property(x => x.BirthDate).HasColumnType(nameof(DataType.Date));
  }
}
