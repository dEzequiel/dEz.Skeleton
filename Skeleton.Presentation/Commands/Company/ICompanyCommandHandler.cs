using Skeleton.Shared.Events.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Presentation.Commands.Company
{
    /// <summary>
    /// Definition of company command handlers.
    /// </summary>
    public interface ICompanyCommandHandler
    {
        Task HandleAsync(AddCompanyCommand command);
        Task HandleAsync(DeleteCompanyCommand command);
        Task HandleAsync(UpdateCompanyCommand command);

    }
}
