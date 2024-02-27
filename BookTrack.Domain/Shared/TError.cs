namespace BookTrack.Domain.Shared;

public class TError : IEquatable<TError>
{
  public static readonly TError None = new(string.Empty, string.Empty);
  public static readonly TError NullValue = new("Error.NullValue", "The specified result value is null.");

  public TError(string code, string message)
  {
    Code = code;
    Message = message;
  }

  public string Code { get; }

  public string Message { get; }

  public static implicit operator string(TError error) => error is null ? "" : error.Code;

  public virtual bool Equals(TError? other)
  {
    if (other is null)
    {
      return false;
    }

    return Code == other.Code && Message == other.Message;
  }

  public override bool Equals(object? obj) => obj is TError error && Equals(error);

  public override int GetHashCode() => HashCode.Combine(Code, Message);

  public override string ToString() => Code;
}
