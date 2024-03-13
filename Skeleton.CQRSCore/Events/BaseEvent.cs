using Skeleton.CQRSCore.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.CQRSCore.Events
{
    /// <summary>
    /// Events are objects that describe something that has occured in the application.
    /// When something important happents in the *, it will raise an event.
    /// </summary>
    public abstract class BaseEvent : Message
    {
        /// <summary>
        /// Version is used to replay the latest state of the aggregate/*.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Discriminator property used for polymortphic data binding 
        /// when serializing event objects.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        protected BaseEvent(string type)
        {
            this.Type = type;
        }
    }
}
