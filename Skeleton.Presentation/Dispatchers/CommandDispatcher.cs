using Skeleton.CQRSCore.Commands;
using Skeleton.CQRSCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Presentation.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        /// <summary>
        /// Registered handlers.
        /// </summary>
        private readonly Dictionary<Type, Func<BaseCommand, Task>> _handlers = new();

        /// <inheritdoc cref="ICommandDispatcher"/>
        public void RegisterHandler<T>(Func<T, Task> handler) where T : BaseCommand
        {
            if(_handlers.ContainsKey(typeof(T)))
            {
                throw new IndexOutOfRangeException("You cannot register the same command handler twice");
            }

            _handlers.Add(typeof(T), x => handler((T)x));
        }

        /// <inheritdoc cref="ICommandDispatcher"/>
        public async Task SendAsync(BaseCommand command)
        {
            if(_handlers.TryGetValue(command.GetType(), out Func<BaseCommand, Task> handler))
            {
                await handler(command);
            } else
            {
                throw new ArgumentNullException(nameof(handler), "No command handler was registered");
            }
        }
    }
}
