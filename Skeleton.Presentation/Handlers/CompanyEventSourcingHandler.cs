using Skeleton.CQRSCore.Domain;
using Skeleton.CQRSCore.Infrastructure;
using Skeleton.Entities.Aggregates;
using Skeleton.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Presentation.Handlers
{
    public class CompanyEventSourcingHandler : IEventSourcingHandler<CompanyAggregate>
    {
        private readonly IEventStore _eventStore;

        /// <inheritdoc cref="IEventSourcingHandler{T}"/>
        public async Task<CompanyAggregate> GetByIdAsync(Guid aggregateId)
        {
            var aggregate = new CompanyAggregate();
            var events = await _eventStore.GetEventsAsync(aggregateId);

            if (events is null || !events.Any()) return aggregate;

            aggregate.ReplayEvents(events);
            aggregate.Version = events.Select(x => x.Version).Max();

            return aggregate;
        }

        /// <inheritdoc cref="IEventSourcingHandler{T}"/>
        public Task RepublishEventsAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IEventSourcingHandler{T}"/>
        public async Task SaveAsync(AggregateRoot aggregate)
        {
            await _eventStore.SaveEventAsync(aggregate.Id, aggregate.GetType().Name, aggregate.GetUncommitedChanges(), aggregate.Version);
            aggregate.MarkChangesAsCommited();
        }
    }
}
