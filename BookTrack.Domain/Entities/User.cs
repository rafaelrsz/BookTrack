using BookTrack.Domain.Primitives;

namespace BookTrack.Domain.Entities;
public class User : Entity
{
  private readonly List<Loan> _loans = [];
  public User(string name, string password, string email)
  {
    Name = name;
    Password = password;
    Email = email;
    CreationDate = DateTime.Now;
    ExpirationDate = DateTime.Now.AddYears(1);
  }

  public string Name { get; private set; }

  public string Password { get; private set; }

  public string Email { get; private set; }

  public DateTime CreationDate { get; private set; }

  public DateTime ExpirationDate { get; private set; }

  public IReadOnlyCollection<Loan> Loans => _loans;

  public void LoanBook(Book book)
  {
    if (book is null)
      return;

    var loan = new Loan(this.Id, book.Id);

    _loans.Add(loan);
  }

  public void RenewLoan(Guid loanId)
  {
    var loan = _loans.FirstOrDefault(p => p.Id == loanId);

    if (loan is null)
      return;

    loan.RenewLoan();
  }
}
