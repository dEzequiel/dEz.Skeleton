using Skeleton.CQRSCore.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Presentation.Commands.Company
{
    /// <summary>
    /// Represents the intention of creating a new company.
    /// </summary>
    public class AddCompanyCommand : BaseCommand
    {
        public string Name { get; set; }
        public string Addresss { get; set; }
        public string Country { get; set; }
    }
}
