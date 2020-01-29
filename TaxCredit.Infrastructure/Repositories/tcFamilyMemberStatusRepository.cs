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
    public class tcFamilyMemberStatusRepository : tcBaseRepository<tcFamilyMemberStatu>, IFamilyMemberStatusRepository
    {

        public tcFamilyMemberStatusRepository(EliteTaxCreditEntities context) : base(context)
        {
        }

        public tcFamilyMemberStatu FindByDescription(string description)
        {
            tcFamilyMemberStatu familyMemberStatus = null;

            familyMemberStatus = _dataContext.tcFamilyMemberStatus.SingleOrDefault(status =>
                status.FamilyMemberStatus.Trim().ToLower() == description.Trim().ToLower());

            return familyMemberStatus;
        }



        public List<tcFamilyMemberStatu> GetAll()
        {
            List<tcFamilyMemberStatu> familyMemberStatuses = null;

            familyMemberStatuses = _dataContext.tcFamilyMemberStatus.ToList();

            return familyMemberStatuses;
        }
    }
}
