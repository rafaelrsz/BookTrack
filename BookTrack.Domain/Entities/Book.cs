using BookTrack.Domain.Enums;
using BookTrack.Domain.Primitives;

namespace BookTrack.Domain.Entities;

public class Book : Entity
{
  public Book(string iSBN, string name, string language, int publicationYear, int pageNumber, Guid authorId, Guid publisherId)
  {
    ISBN = iSBN;
    Name = name;
    Language = language;
    PublicationYear = publicationYear;
    PageNumber = pageNumber;
    AuthorId = authorId;
    PublisherId = publisherId;
    Status = EBookStatus.Available;
  }

  public string ISBN { get; private set; }

  public string Name { get; private set; }
  
  public string Language { get; private set; } 
  
  public int PublicationYear { get; private set; }

  public int PageNumber { get; private set; }

  public Guid AuthorId { get; private set; }

  public Guid PublisherId { get; private set; }

  public EBookStatus Status { get; private set; } 
}
