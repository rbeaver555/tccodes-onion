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
    public class tcDTIncomeTypeRepository : tcBaseRepository<tcDTIncomeType>, IDTIncomeTypeRepository
    {


        public tcDTIncomeTypeRepository(EliteTaxCreditEntities context) : base(context)
        {
        }

        public tcDTIncomeType FindByDescription(string description)
        {
            tcDTIncomeType IncomeType = null;

            IncomeType = _dataContext.tcDTIncomeTypes.SingleOrDefault(status =>
                status.IncomeType.Trim().ToLower() == description.Trim().ToLower());

            return IncomeType;
        }



        public List<tcDTIncomeType> GetAll()
        {
            List<tcDTIncomeType> IncomeTypees = null;

            IncomeTypees = _dataContext.tcDTIncomeTypes.ToList();

            return IncomeTypees;
        }
    }
}
