using BookTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTrack.Infra.Data.Mappings;
public class BookConfiguration : IEntityTypeConfiguration<Book>
{
  public void Configure(EntityTypeBuilder<Book> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.ISBN)
           .HasMaxLength(13);

    builder.Property(x => x.Name)
           .HasMaxLength(255);  
    
    builder.Property(x => x.Language)
           .HasMaxLength(2);  

    builder.Property(x => x.PublicationYear);

    builder.Property(x => x.PageNumber);

    builder.Property(x => x.Status);

    builder.HasOne<Author>()
           .WithMany(a => a.Books)
           .HasForeignKey(x => x.AuthorId)
           .OnDelete(DeleteBehavior.Cascade); 
    
    builder.HasOne<Publisher>()
           .WithMany(p => p.Books)
           .HasForeignKey(x => x.PublisherId)
           .OnDelete(DeleteBehavior.Cascade);
  }
}
