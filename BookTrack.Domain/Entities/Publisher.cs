using BookTrack.Domain.Primitives;

namespace BookTrack.Domain.Entities;

public class Publisher : Entity
{
  private readonly List<Book> _books = [];
  public Publisher(string name, string phone, int foundationDate)
  {
    Name = name;
    Phone = phone;
    FoundationDate = foundationDate;
  }

  public string Name { get; private set; }

  public string Phone { get; private set; }

  public int FoundationDate { get; private set; }

  public IReadOnlyCollection<Book> Books => _books;

  public void AddBook(Book book)
  {
    _books.Add(book);
  }
}
