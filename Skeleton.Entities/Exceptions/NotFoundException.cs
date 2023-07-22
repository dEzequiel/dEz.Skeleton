namespace Skeleton.Entities.Exceptions;

public abstract class NotFoundException : Exception
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message"></param>
    protected NotFoundException(string message)
        : base(message) { }
}