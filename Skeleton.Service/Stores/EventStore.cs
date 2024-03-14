using Skeleton.Abstraction;
using Skeleton.CQRSCore.Domain.Exceptions;
using Skeleton.CQRSCore.Events;
using Skeleton.Entities.Exceptions.Aggregate;
using Skeleton.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Service.Stores
{
    public class EventStore : IEventStore
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;

        public EventStore(IUnitOfWork unitOfWork, ILoggerManager logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <inheritdoc cref="IEventStore"/>
        public async Task<IEnumerable<BaseEvent>> GetEventsAsync(Guid aggregateId)
        {
            var eventStream = await _unitOfWork.EventStoreRepository.FindByAggregateId(aggregateId);

            if (eventStream is null || !eventStream.Any())
                throw new AggregateNotFoundException(aggregateId);

            return eventStream.OrderBy(x => x.Version).Select(x => x.EventData).ToList();
        }

        /// <inheritdoc cref="IEventStore"/>
        public async Task SaveEventAsync(Guid aggregateId, string aggregateType, IEnumerable<BaseEvent> events, int expectedVersion)
        {
            var eventStream = await _unitOfWork.EventStoreRepository.FindByAggregateId(aggregateId);

            // Check if the expected version is specified and compare it with the version of the last event in the stream.
            // If they do not match, throw a ConcurrencyException.
            if (expectedVersion != -1 && eventStream.Last().Version != expectedVersion)
                throw new ConcurrencyException();

            var version = expectedVersion;

            foreach(var @event in events)
            {
                version++;
                @event.Version = version;
                var eventType = @event.GetType().Name;
                var eventModel = new EventModel
                {
                    TimeStamp = DateTime.Now,
                    AggregateIdentifier = aggregateId,
                    AggregateType = aggregateType,
                    Version = version,
                    EventType = eventType,
                    EventData = @event
                };

                _unitOfWork.EventStoreRepository.SaveAsync(eventModel);
            }

        }

        /// <inheritdoc cref="IDisposable"/>
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
