using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCredit.Core.Models;

namespace TaxCredit.Core.Interfaces.Repositories
{
    public interface IAssetRepository
    {
        IEnumerable<tcAsset> GetAssetsByFamily(int familyID);

        IEnumerable<tcAsset> GetAssetsWithIncomesByFamily(int familyID);
    }
}
