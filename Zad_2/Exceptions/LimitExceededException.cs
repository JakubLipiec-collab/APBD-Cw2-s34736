namespace Zad_2.Exceptions;

public class LimitExceededException : Exception
{
    public LimitExceededException(string message) : base(message) {}
}