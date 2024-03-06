namespace BookTrack.Domain.Primitives;

public class Entity
{
  public Entity(Guid id)
  {
    Id = id == Guid.Empty ? Guid.NewGuid() : id;
  }

  public Guid Id { get; private set; }
}
