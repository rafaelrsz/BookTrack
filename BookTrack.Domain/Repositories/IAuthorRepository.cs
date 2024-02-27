using BookTrack.Domain.Entities;

namespace BookTrack.Domain.Repositories;
public interface IAuthorRepository
{
  public void Add(Author author);

  public Task<Author?> GetByIdAsync(Guid authorId);
}
