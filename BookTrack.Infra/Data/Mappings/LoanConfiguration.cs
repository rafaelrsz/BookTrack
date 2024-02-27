using BookTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTrack.Infra.Data.Mappings;
public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
  public void Configure(EntityTypeBuilder<Loan> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.LoanStatus);

    builder.Property(x => x.LoanDate);

    builder.Property(x => x.ExpectedReturnDate);

    builder.Property(x => x.UserId);
    builder.Property(x => x.BookId);

    builder.HasOne<User>()
           .WithMany(u => u.Loans)
           .HasForeignKey(x => x.UserId)
           .OnDelete(DeleteBehavior.Restrict);

    builder.HasOne<Book>()
           .WithMany()
           .HasForeignKey(x => x.BookId)
           .OnDelete(DeleteBehavior.Restrict);
  }
}
