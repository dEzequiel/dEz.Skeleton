namespace Skeleton.Entities.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a collection of ids is empty.
/// This exception is used to indicate that a collection of ids is empty or null.
/// </summary>
public sealed class IdParametersBadRequestException : BadRequestException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IdParametersBadRequestException"/> class
    /// </summary>
    public IdParametersBadRequestException()
        :base("Parameter ids is null")
    {
    }
}