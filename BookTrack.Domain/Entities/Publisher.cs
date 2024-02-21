using BookTrack.Domain.Primitives;

namespace BookTrack.Domain.Entities;

public class Publisher : Entity
{
  private readonly List<Book> _books = [];
  public Publisher(string name, string address, string email, string phone)
  {
    Name = name;
    Address = address;
    Email = email;
    Phone = phone;
  }

  public string Name { get; private set; }
  public string Address { get; private set; }
  public string Email { get; private set; }
  public string Phone { get; private set; }
  public IReadOnlyCollection<Book> Books => _books;
}
