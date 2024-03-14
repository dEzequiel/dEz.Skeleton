using Skeleton.CQRSCore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Abstraction.Repository
{
    public interface IEventStoreRepository
    {
        /// <summary>
        /// Store an event.
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        void SaveAsync(EventModel @event);

        /// <summary>
        /// Asynchronously retrieves all events related to a aggregate.
        /// </summary>
        /// <param name="aggregateId">The unique identifier of the aggregate to retrieve events.</param>
        /// <returns>A task representing the asynchronous operation, returning an enumerable collection of
        /// <see cref="EventModel"/>.</returns>
        Task<IEnumerable<EventModel>> FindByAggregateId(Guid aggregateId);
    }
}
