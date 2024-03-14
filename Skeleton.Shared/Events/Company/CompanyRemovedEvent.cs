using Skeleton.CQRSCore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Shared.Events.Company
{
    /// <summary>
    /// CompanyRemovedEvent will be raised when the company removed command has been handled.
    /// </summary>
    public class CompanyRemovedEvent : BaseEvent
    {
        public CompanyRemovedEvent() : base(nameof(CompanyRemovedEvent))
        {
        }

        public Guid CompanyId { get; set; }
    }
}
