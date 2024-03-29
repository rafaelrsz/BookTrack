﻿using BookTrack.Domain.Entities;

namespace BookTrack.Domain.Repositories;
public interface IAuthorRepository
{
  public void Add(Author author);

  public Task<Author?> GetByIdAsync(Guid authorId);

  public Task<Author?> GetByIdAsyncAsNoTracking(Guid authorId);

  public Task<bool> IsNameUniqueAsync(string name);

  public Task DeleteAsync(Guid authorId);

  public void Update(Author author);
}
