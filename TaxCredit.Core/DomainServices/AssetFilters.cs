using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCredit.Core.Interfaces.DomainServices;
using TaxCredit.Core.Interfaces.Repositories;
using TaxCredit.Core.Models;

namespace TaxCredit.Core.DomainServices
{
    public sealed class AssetFilters : IAssetFilters
    {
        public IEnumerable<tcAsset> RemoveInactiveAssetsFromCollection(IEnumerable<tcAsset> assets)
        {
            return assets.Where(asset => asset.IsActive == true);
        }

        public IEnumerable<tcAsset> RemoveInEligibleFamilyMemberAssetsFromCollection(IEnumerable<tcAsset> assets)
        {
            return assets.Where(asset =>
                asset.tcFamilyMember.IsActive &&
                asset.tcFamilyMember.tcFamilyMemberStatu.FamilyMemberStatus.Trim().ToLower() != Constants.FamilyMemberStatus.NonEligibleFamilyMember.Trim().ToLower() &&
                asset.tcFamilyMember.tcFamilyMemberStatu.FamilyMemberStatus.Trim().ToLower() != Constants.FamilyMemberStatus.LiveInAide.Trim().ToLower());

        }

    }
}
