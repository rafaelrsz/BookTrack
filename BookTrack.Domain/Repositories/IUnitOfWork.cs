﻿namespace BookTrack.Domain.Repositories;
public interface IUnitOfWork
{
  Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
