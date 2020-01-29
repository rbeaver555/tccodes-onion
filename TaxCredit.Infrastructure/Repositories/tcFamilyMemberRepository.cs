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
    public class tcFamilyMemberRepository : tcBaseRepository<tcFamilyMember>, IFamilyMemberRepository
    {
        public tcFamilyMemberRepository(EliteTaxCreditEntities context) : base(context)
        { }

        public IEnumerable<tcFamilyMember> GetFamilyMembersByFamilyID(int familyID)
        {
            return Get(member => member.fkFamily == familyID, null, "tcFamilyMemberStatu, tcFamily");
        }
    }
}
