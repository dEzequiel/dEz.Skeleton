namespace Skeleton.Entities.Exceptions;

/// <summary>
/// Represents a custom exception for Bad Request errors.
/// </summary>
public abstract class BadRequestException : Exception
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message"></param>
    protected BadRequestException(string message)
        :base(message)
    {
    }
}