using BookTrack.Domain.Repositories;
using BookTrack.Infra.Data;

namespace BookTrack.Infra.Implementations;

public sealed class UnitOfWork : IUnitOfWork
{
  private readonly BookTrackContext _context;

  public UnitOfWork(BookTrackContext context)
  {
    _context = context;
  }
  public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
  }
}
