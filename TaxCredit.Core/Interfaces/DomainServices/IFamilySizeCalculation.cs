using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCredit.Core.Models;
using TaxCredit.Core.Interfaces.Repositories;

namespace TaxCredit.Core.Interfaces.DomainServices
{
    public interface IFamilySizeCalculation
    {
        int CalculateFamilySize(tcFamily familyArg, IFamilyMemberRepository familyMemberRepo);
    }
}
