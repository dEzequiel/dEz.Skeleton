using Skeleton.CQRSCore.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Presentation.Commands.Company
{
    /// <summary>
    /// Represents the intention of deleting a company.
    /// </summary>
    public class DeleteCompanyCommand : BaseCommand
    {
        public Guid CompanyId { get; set; }
    }
}
