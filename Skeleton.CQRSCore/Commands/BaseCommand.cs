using Skeleton.CQRSCore.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.CQRSCore.Commands
{
    /// <summary>
    /// Command is a expressed intent of doing an action. Also contains information
    /// that is required to do the desired action.
    /// </summary>
    public abstract class BaseCommand : Message
    {
    }
}
