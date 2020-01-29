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
    public class tcDTFamilyMemberStatusRepository : tcBaseRepository<tcFamilyMemberStatu>, IDTFamilyMemberStatusRepository
    {


        public tcDTFamilyMemberStatusRepository(EliteTaxCreditEntities context) : base(context)
        {
        }


        public tcDTFamilyMemberStatu FindByDescription(string description)
        {
            tcDTFamilyMemberStatu familyMemberStatus = null;

            familyMemberStatus = _dataContext.tcDTFamilyMemberStatus.SingleOrDefault(status =>
                status.FamilyMemberStatus.Trim().ToLower() == description.Trim().ToLower());


            return familyMemberStatus;
        }



        public List<tcDTFamilyMemberStatu> GetAll()
        {
            List<tcDTFamilyMemberStatu> familyMemberStatuses = null;


            familyMemberStatuses = _dataContext.tcDTFamilyMemberStatus.ToList();


            return familyMemberStatuses;
        }
    }
}
