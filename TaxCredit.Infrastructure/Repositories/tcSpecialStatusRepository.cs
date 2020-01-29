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
    public class tcSpecialStatusRepository : tcBaseRepository<tcSpecialStatu>, ISpecialStatusRepository
    {

        public tcSpecialStatusRepository(EliteTaxCreditEntities context) : base(context)
        {
        }

        public tcSpecialStatu FindByDescription(string description)
        {
            tcSpecialStatu specialStatus = null;

            specialStatus = _dataContext.tcSpecialStatus.SingleOrDefault(status =>
                status.SpecialStatus.Trim().ToLower() == description.Trim().ToLower());

            return specialStatus;
        }



        public List<tcSpecialStatu> GetAll()
        {
            List<tcSpecialStatu> specialStatus = null;

            specialStatus = _dataContext.tcSpecialStatus.ToList();

            return specialStatus;
        }
    }
}
