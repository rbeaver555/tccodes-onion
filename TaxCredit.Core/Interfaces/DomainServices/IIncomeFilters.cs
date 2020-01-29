using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCredit.Core.Models;

namespace TaxCredit.Core.Interfaces.DomainServices
{
    public interface IIncomeFilters
    {
        IEnumerable<tcIncome> RemoveInEligibleFamilyMemberIncomesFromCollection(IEnumerable<tcIncome> incomes);

        IEnumerable<tcIncome> RemoveEarnedIncomesOfDependentsUnder18(IEnumerable<tcIncome> incomes);

        IEnumerable<tcIncome> RetrieveAdultStudentIncome(IEnumerable<tcIncome> incomes);
    }
}
