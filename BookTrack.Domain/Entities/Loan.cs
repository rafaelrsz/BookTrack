using BookTrack.Domain.Enums;
using BookTrack.Domain.Primitives;

namespace BookTrack.Domain.Entities;
public class Loan : Entity
{
  public Loan(Guid userId, Guid bookId, Guid id = default) : base(id)
  {
    LoanDate = DateTime.Now;
    ExpectedReturnDate = DateTime.Now.AddDays(15);
    UserId = userId;
    BookId = bookId;
    LoanStatus = ELoanStatus.Current;
  }

  public DateTime LoanDate { get; set; }

  public DateTime ExpectedReturnDate { get; set; }

  public Guid UserId { get; private set; }

  public Guid BookId { get; private set; }

  public ELoanStatus LoanStatus { get; private set; }

  public void RenewLoan()
  {
    ExpectedReturnDate.AddDays(15);
  }
}
