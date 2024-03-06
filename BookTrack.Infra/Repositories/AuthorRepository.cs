using BookTrack.Domain.Entities;
using BookTrack.Domain.Repositories;
using BookTrack.Infra.Data;
using Microsoft.EntityFrameworkCore;

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

  public async Task DeleteAsync(Guid authorId)
  {
    var entity = await GetByIdAsync(authorId).ConfigureAwait(false);

    if (entity is null)
      return;

    _context.Remove(entity);
  }

  public async Task<Author?> GetByIdAsync(Guid authorId)
  {
    return await _context.Authors.FirstOrDefaultAsync(x => x.Id == authorId).ConfigureAwait(false);
  }

  public async Task<Author?> GetByIdAsyncAsNoTracking(Guid authorId)
  {
    return await _context.Authors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == authorId).ConfigureAwait(false);
  }

  public async Task<bool> IsNameUniqueAsync(string name)
  {
    return !(await _context.Authors.AnyAsync(x => x.Name == name).ConfigureAwait(false));
  }

  public void Update(Author author)
  {
    _context.Authors.Update(author);
  }
}
