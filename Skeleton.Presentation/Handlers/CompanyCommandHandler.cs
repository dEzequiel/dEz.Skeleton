using Skeleton.CQRSCore.Infrastructure;
using Skeleton.Entities.Aggregates;
using Skeleton.Presentation.Commands.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Presentation.Handlers
{
    /// <summary>
    /// Command handler implementation for company related commands.
    /// </summary>
    public class CompanyCommandHandler : ICompanyCommandHandler
    {
        private readonly IEventSourcingHandler<CompanyAggregate> _eventSourcingHandler;

        public CompanyCommandHandler(IEventSourcingHandler<CompanyAggregate> eventSourcingHandler)
        {
            _eventSourcingHandler = eventSourcingHandler;
        }

        /// <inheritdoc cref="ICompanyCommandHandler"/>
        public async Task HandleAsync(AddCompanyCommand command)
        {
            var aggregate = new CompanyAggregate(command.Id, command.Name, command.Addresss, command.Country);
            await _eventSourcingHandler.SaveAsync(aggregate);
        }

        /// <inheritdoc cref="ICompanyCommandHandler"/>
        public async Task HandleAsync(DeleteCompanyCommand command)
        {
            var aggregate = await _eventSourcingHandler.GetByIdAsync(command.Id);
            aggregate.DeleteCompany(command.CompanyId);

            await _eventSourcingHandler.SaveAsync(aggregate);
        }

        /// <inheritdoc cref="ICompanyCommandHandler"/>
        public async Task HandleAsync(UpdateCompanyCommand command)
        {
            var aggregate = await _eventSourcingHandler.GetByIdAsync(command.Id);
            aggregate.UpdateCompany(command.CompanyId, command.Name, command.Country, command.Address);

            await _eventSourcingHandler.SaveAsync(aggregate);
        }
    }
}
