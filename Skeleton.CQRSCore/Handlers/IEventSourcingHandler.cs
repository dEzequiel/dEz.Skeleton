using Skeleton.CQRSCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.CQRSCore.Handlers
{
    /// <summary>
    /// Interface defining operations for saving and retrieving aggregates and republishing events.
    /// </summary>
    public interface IEventSourcingHandler<T>
    {
        /// <summary>
        /// Saves the provided aggregate.
        /// </summary>
        /// <param name="aggregate">The aggregate to save.</param>
        Task SaveAsync(AggregateRoot aggregate);

        /// <summary>
        /// Retrieves an aggregate by its unique identifier.
        /// </summary>
        /// <param name="aggregateId">The unique identifier of the aggregate.</param>
        /// <returns>The retrieved aggregate.</returns>
        Task<T> GetByIdAsync(Guid aggregateId);

        /// <summary>
        /// Republishes events.
        /// </summary>
        Task RepublishEventsAsync();
    }
}
