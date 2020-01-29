using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCredit.Core.Interfaces.Repositories;
using TaxCredit.Core.Models;
using TaxCredit.Infrastructure.Data;

namespace TaxCredit.Infrastructure.Repositories
{
    public class tcIncomeRepository : tcBaseRepository<tcIncome>, IIncomeRepository
    {
        
        public tcIncomeRepository(EliteTaxCreditEntities context) : base(context)
        {            
        }

        public IEnumerable<tcIncome> GetIncomesByFamily(int familyID)
        {
            return Get(incomes => incomes.tcFamilyMember.fkFamily == familyID, null, "tcFamilyMember, tcFamilyMember.tcFamilyMemberStatu, tcIncomeType");
        }

    }
}
