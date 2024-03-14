using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Entities.Exceptions.Aggregate
{
    public sealed class AggregateNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateNotFoundException"/> class
        /// with the provided company ID that was not found.
        /// </summary>
        /// <param name="companyId">The ID of the company that was not found.</param>
        public AggregateNotFoundException(Guid aggregateId)
            : base($"Aggregate with ID: {aggregateId} not found.") { }
    
    }
}
