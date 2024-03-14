namespace Skeleton.CQRSCore.Events
{
    public class EventModel 
    {
        /// <summary>
        /// Event stored identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Time stamp when the event is persisted.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Aggregate identifier that the events relates to.
        /// </summary>
        public Guid AggregateIdentifier { get; set; }

        /// <summary>
        /// Aggregate type.
        /// </summary>
        public string AggregateType { get; set; }

        /// <summary>
        /// Version of the aggregate at this point in time.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Event type.
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// Polymorphism allow us to assign an instance of a concrete event object to the base event.
        /// That will ensure that we have all of the event information.
        /// 
        /// Useful for replaying the event store.
        /// </summary>
        public BaseEvent EventData { get; set; }
    }
}
