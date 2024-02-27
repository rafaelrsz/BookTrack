namespace BookTrack.Domain.Shared;

public class Result
{
    protected internal Result(bool isSuccess, TError error)
    {
        if (isSuccess && error != TError.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == TError.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public TError Error { get; }

    public static Result Success() => new(true, TError.None);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, TError.None);

    public static Result Failure(TError error) => new(false, error);

    public static Result<TValue> Failure<TValue>(TError error) => new(default, false, error);

    public static Result<TValue> Create<TValue>(TValue? value) => value is not null ? Success(value) : Failure<TValue>(TError.NullValue);
}
