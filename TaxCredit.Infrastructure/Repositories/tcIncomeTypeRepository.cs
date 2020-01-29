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
    public class tcIncomeTypeRepository : tcBaseRepository<tcIncomeTypeRepository>, IIncomeTypeRepository
    {

        public tcIncomeTypeRepository(EliteTaxCreditEntities context) : base(context)
        {
        }

        public tcIncomeType FindByDescription(string description)
        {
            tcIncomeType IncomeType = null;

            IncomeType = _dataContext.tcIncomeTypes.SingleOrDefault(status =>
                status.IncomeType.Trim().ToLower() == description.Trim().ToLower());

            return IncomeType;
        }



        public List<tcIncomeType> GetAll()
        {
            List<tcIncomeType> IncomeTypees = null;

            IncomeTypees = _dataContext.tcIncomeTypes.ToList();

            return IncomeTypees;
        }
    }
}
