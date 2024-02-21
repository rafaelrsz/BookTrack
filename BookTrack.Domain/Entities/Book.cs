using BookTrack.Domain.Primitives;

namespace BookTrack.Domain.Entities;

public class Book : Entity
{
  public Book(string iSBN, string name, string language, string summary, int publicationYear, int pageNumber, Author author, Publisher publisher)
  {
    ISBN = iSBN;
    Name = name;
    Language = language;
    Summary = summary;
    PublicationYear = publicationYear;
    PageNumber = pageNumber;
    Author = author;
    Publisher = publisher;
  }

  public string ISBN { get; private set; }
  public string Name { get; private set; } 
  public string Language { get; private set; } 
  public string Summary { get; private set; } 
  public int PublicationYear { get; private set; }
  public int PageNumber { get; private set; }
  public Author Author { get; private set; }
  public Publisher Publisher { get; private set; }
}
