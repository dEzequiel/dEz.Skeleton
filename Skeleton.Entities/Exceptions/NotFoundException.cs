namespace Skeleton.Entities.Exceptions;

/// <summary>
/// Represents a custom exception for Not Found errors.
/// </summary>
public abstract class NotFoundException : Exception
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message"></param>
    protected NotFoundException(string message)
        : base(message) { }
}