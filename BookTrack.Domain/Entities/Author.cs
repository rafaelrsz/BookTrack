using BookTrack.Domain.Primitives;

namespace BookTrack.Domain.Entities;

public class Author : Entity
{
  private readonly List<Book> _books = [];

  public Author(string name, string nationality, DateTime birthDate, Guid id = default) : base(id)
  {
    Name = name;
    Nationality = nationality;
    BirthDate = birthDate;
  }

  public string Name { get; private set; } 

  public string Nationality { get; private set; } 

  public DateTime BirthDate { get; private set; }

  public IReadOnlyCollection<Book> Books => _books;

  public void AddBook(Book book)
  {
    _books.Add(book);
  }
}
