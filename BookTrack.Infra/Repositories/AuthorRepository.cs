using BookTrack.Domain.Entities;
using BookTrack.Domain.Repositories;
using BookTrack.Infra.Data;

namespace BookTrack.Infra.Repositories;
public class AuthorRepository : IAuthorRepository
{
  private readonly BookTrackContext _context;
  public AuthorRepository(BookTrackContext context)
  {
    _context = context;
  }
  public void Add(Author author)
  {
    _context.Authors.Add(author);
  }

  public Task<Author?> GetByIdAsync(Guid authorId)
  {
    throw new NotImplementedException();
  }
}
