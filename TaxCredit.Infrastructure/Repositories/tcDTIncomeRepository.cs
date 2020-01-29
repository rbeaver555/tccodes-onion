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
    public class tcDTIncomeRepository : tcBaseRepository<tcDTIncome>, IDTIncomeRepository
    {
        
        public tcDTIncomeRepository(EliteTaxCreditEntities context) : base(context)
        {
        }

      
        
    }
}
