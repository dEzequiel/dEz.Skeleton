using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.CQRSCore.Messages
{
    /// <summary>
    /// Message represents types of commands, events and queries.
    /// </summary>
    public abstract class Message
    {
        /// <summary>
        /// Message identifier.
        /// </summary>
        public Guid Id { get; set; }
    }
}
