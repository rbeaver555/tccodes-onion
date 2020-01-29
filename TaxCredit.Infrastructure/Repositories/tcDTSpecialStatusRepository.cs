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
    public class tcDTSpecialStatusRepository : tcBaseRepository<tcDTSpecialStatu>, IDTSpecialStatusRepository
    {


        public tcDTSpecialStatusRepository(EliteTaxCreditEntities context) : base(context)
        {
        }


        public tcDTSpecialStatu FindByDescription(string description)
        {
            tcDTSpecialStatu specialStatus = null;

            specialStatus = _dataContext.tcDTSpecialStatus.SingleOrDefault(status =>
                status.SpecialStatus.Trim().ToLower() == description.Trim().ToLower());

            return specialStatus;
        }



        public List<tcDTSpecialStatu> GetAll()
        {
            List<tcDTSpecialStatu> specialStatus = null;

            specialStatus = _dataContext.tcDTSpecialStatus.ToList();

            return specialStatus;
        }
    }
}
