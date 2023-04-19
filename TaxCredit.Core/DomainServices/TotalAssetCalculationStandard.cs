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
    public class TotalAssetCalculationStandard : ITotalAssetCalculation
    {
        public decimal CalculateTotalAssetAmount(tcFamily familyArg, IAssetRepository assetRepo)
        {
            decimal totalAssetValue = 0;

            //incremental holding values                        
            decimal totalWithDrawlPenalty = 0;

            //1. Get all eligible assets
            IEnumerable<tcAsset> eligibleAssets = ReturnTotalEligibleAssetsForFamily(familyArg, assetRepo);

            //2. Snag the total asset value for the family
            totalAssetValue = eligibleAssets.Sum(asset => asset.Value);

            //3. Snag the total withdrawl penalty
            totalWithDrawlPenalty = eligibleAssets.Sum(asset => (asset.WithdrawlPenalty ?? 0));

            //4. Remove the penalty from the total asset value
            totalAssetValue = totalAssetValue - totalWithDrawlPenalty;

            return totalAssetValue;
        }

        public IEnumerable<tcAsset> ReturnTotalEligibleAssetsForFamily(tcFamily familyArg, IAssetRepository assetRepo)
        {
            //1. Snag the total asset value for the family
            IEnumerable<tcAsset> assets = assetRepo.GetAssetsByFamily(familyArg.PK);

            //2. Filter out inactive assets
            assets = new AssetFilters().RemoveInactiveAssetsFromCollection(assets);

            //3. Filter out ineligible family members
            assets = new AssetFilters().RemoveInEligibleFamilyMemberAssetsFromCollection(assets);

            return assets;
        }

        //create a function that takes a string and returns it in reverse
        public string ReverseString(string input)
        {
            string output = string.Empty;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                output += input[i];
            }
            return output;
        }

        //create a function that utilizes a regex to validate email addresses
        public bool ValidateEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        //build a new function to calculate the total asset value for a family with a conditional statement that caps asset value to 10000


        

    }
}
