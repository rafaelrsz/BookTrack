using BookTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookTrack.Infra.Data;
public class BookTrackContext : DbContext
{
  public BookTrackContext(DbContextOptions<BookTrackContext> options) : base(options)
  {
    
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookTrackContext).Assembly);
  }

  public DbSet<Author> Authors { get; set; }
  public DbSet<Book> Books { get; set; }
  public DbSet<Loan> Loans { get; set; }
  public DbSet<Publisher> Publishers { get; set; }
  public DbSet<User> Users { get; set; }
}
