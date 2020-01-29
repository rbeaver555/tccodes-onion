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
    public class tcAssetRepository : tcBaseRepository<tcAsset>, IAssetRepository
    {
        public tcAssetRepository(EliteTaxCreditEntities context) : base(context)
        { }


        public IEnumerable<tcAsset> GetAssetsByFamily(int familyID)
        {
            return Get(asset => asset.tcFamilyMember.fkFamily == familyID, null, 
                "tcFamilyMember, tcFamilyMember.tcFamilyMemberStatu");
        }

        public IEnumerable<tcAsset> GetAssetsWithIncomesByFamily(int familyID)
        {
            return Get(asset => asset.tcFamilyMember.fkFamily == familyID && asset.AnnualIncome != null
            && asset.AnnualIncome > 0, null, "tcFamilyMember, tcFamilyMember.tcFamilyMemberStatu");
        }
    }
}
