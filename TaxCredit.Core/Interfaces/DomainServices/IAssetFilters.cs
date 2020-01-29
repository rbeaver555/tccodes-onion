using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCredit.Core.Interfaces.DomainServices;
using TaxCredit.Core.Interfaces.Repositories;
using TaxCredit.Core.Models;

namespace TaxCredit.Core.Interfaces.DomainServices
{
    public interface IAssetFilters
    {
        IEnumerable<tcAsset> RemoveInactiveAssetsFromCollection(IEnumerable<tcAsset> assets);

        IEnumerable<tcAsset> RemoveInEligibleFamilyMemberAssetsFromCollection(IEnumerable<tcAsset> assets);
    }
}
