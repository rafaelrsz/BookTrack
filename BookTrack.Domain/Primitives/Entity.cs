namespace BookTrack.Domain.Primitives;

public class Entity
{
  public Guid Id { get; set; } = Guid.NewGuid();
}
