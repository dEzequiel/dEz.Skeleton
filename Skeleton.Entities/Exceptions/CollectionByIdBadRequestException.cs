namespace Skeleton.Entities.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a collection of ids mismatch from the obtained entities.
/// This exception is used to indicate that a collection of ids mismatch from the obtained entities.
/// </summary>
public sealed class CollectionByIdsBadRequestException : BadRequestException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CollectionByIdsBadRequestException"/> class
    /// </summary>
    public CollectionByIdsBadRequestException()
        :base("Collection count mismatch comparing to ids.")
    {
    }
}