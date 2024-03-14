using Skeleton.CQRSCore.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Presentation.Commands.Company
{
    /// <summary>
    /// Represents the intention of updating a company.
    /// </summary>
    public class UpdateCompanyCommand : BaseCommand
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}
