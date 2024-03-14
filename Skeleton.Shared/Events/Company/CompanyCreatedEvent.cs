using Skeleton.CQRSCore.Events;

namespace Skeleton.Presentation.Events.Company
{
    /// <summary>
    /// CompanyCreatedEvent will be raised when the company created command has been handled.
    /// </summary>
    public class CompanyCreatedEvent : BaseEvent
    {
        public CompanyCreatedEvent() : base(nameof(CompanyCreatedEvent))
        {
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}
