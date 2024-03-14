using Microsoft.EntityFrameworkCore;
using Skeleton.Abstraction.Repository;
using Skeleton.CQRSCore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Repository
{
    /// <summary>
    /// Repository implementation for events-related operations.
    /// </summary>
    public sealed class EventStoreRepository : RepositoryBase<EventModel>, IEventStoreRepository
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositoryContext"></param>
        public EventStoreRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        ///<inheritdoc cref="IEventStoreRepository"/>
        public async Task<IEnumerable<EventModel>> FindByAggregateId(Guid aggregateId) =>
            await FindAll(false).Where(e => e.AggregateIdentifier.Equals(aggregateId)).ToListAsync();

        ///<inheritdoc cref="IEventStoreRepository"/>
        public void SaveAsync(EventModel @event) =>
            Create(@event);
    }
}
