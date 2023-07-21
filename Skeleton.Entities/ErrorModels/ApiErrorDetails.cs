using System.Text.Json;

namespace Skeleton.Entities.ErrorModels;

/// <summary>
/// Friendly error representation.
/// </summary>
public class ApiErrorDetails
{
    /// <summary>
    /// Request HTTP status code.
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// Error message.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Request path.
    /// </summary>
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// Request method.
    /// </summary>
    public string Method { get; set; } = string.Empty;

    /// <summary>
    /// Serialize object to JavaScript Object Notation.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => JsonSerializer.Serialize(this);
}