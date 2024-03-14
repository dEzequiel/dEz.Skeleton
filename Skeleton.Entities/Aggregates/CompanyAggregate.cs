using Skeleton.CQRSCore.Domain;
using Skeleton.Presentation.Events.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Skeleton.Entities.Aggregates
{
    public class CompanyAggregate : AggregateRoot
    {
        private string _name;
        private bool _active;
        
        public bool IsActive { get => _active ; set { _active = value;} }

        public CompanyAggregate() { }

        /// <summary>
        /// Once the aggregate instance creation event is raised, RaiseEvent invokes the
        /// ApplyChange() method.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="country"></param>
        public CompanyAggregate(Guid id, string name, string address, string country)
        {
            RaiseEvent(new CompanyCreatedEvent
            {
                Id = id,
                Name = name,
                Address = address,
                Country = country
            });
            
        }

        /// <summary>
        /// When CompanyCreatedEvent is raised, it will invoke the apply method for applying the company.
        /// </summary>
        /// <param name="event"></param>
        public void Apply(CompanyCreatedEvent @event)
        {
            _id = @event.Id;
            _active = true;
            _name = @event.Name;
        }
    }
}
