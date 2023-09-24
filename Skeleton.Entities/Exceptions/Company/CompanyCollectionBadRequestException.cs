namespace Skeleton.Entities.Exceptions.Company
{
    /// <summary>
    /// Represents an exception that is thrown when a collection of companies for add is empty.
    /// This exception is used to indicate that a collection of companies is empty or null.
    /// </summary>
    public sealed class CompanyCollectionBadRequestException : BadRequestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyCollectionBadRequest"/> class
        /// </summary>
        public CompanyCollectionBadRequestException()
            : base("Company collection sent from a client is null.")
        {
        }
    }
}
