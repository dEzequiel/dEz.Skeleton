using Skeleton.CQRSCore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Service.Abstraction
{
    public interface IEventStore : IServiceBase
    {
        /// <summary>
        /// Persist a new event asynchronously.
        /// 
        /// Saves all unsafe changes to the aggregate in the form of events.
        /// </summary>
        /// <param name="aggregateId"></param>
        /// <param name="events"></param>
        /// <param name="expectedVersion"></param>
        /// <returns></returns>
        Task SaveEventAsync(Guid aggregateId, string aggregateType, IEnumerable<BaseEvent> events, int expectedVersion);
        
        /// <summary>
        /// Return all events realted to an aggregate asynchronously.
        /// </summary>
        /// <param name="aggregateId"></param>
        /// <returns></returns>
        Task<IEnumerable<BaseEvent>> GetEventsAsync(Guid aggregateId);
        
    }
}
