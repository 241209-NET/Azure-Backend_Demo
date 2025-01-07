namespace PetTracker.API.PetException;

public class NoOwnerException : Exception
{
    public NoOwnerException(){}
    public NoOwnerException(string message) : base(message){}
    public NoOwnerException(string message, Exception inner) : base(message, inner){}
}