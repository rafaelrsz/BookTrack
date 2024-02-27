using BookTrack.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookTrack.Api.Extentions;

public static class MigrationExtentions
{
  public static void ApplyMigrations(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();

    var dbContext = scope.ServiceProvider.GetRequiredService<BookTrackContext>();

    dbContext.Database.Migrate();
  }
}
