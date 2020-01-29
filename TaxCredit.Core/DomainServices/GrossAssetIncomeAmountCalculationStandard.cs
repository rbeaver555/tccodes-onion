using System.Collections.Generic;
using System.Linq;
using TaxCredit.Core.Interfaces.DomainServices;
using TaxCredit.Core.Interfaces.Repositories;
using TaxCredit.Core.Models;

namespace TaxCredit.Core.DomainServices
{
    public class GrossAssetIncomeAmountCalculationStandard : IGrossAssetIncomeAmountCalculation
    {
        public decimal CalculateTotalAssetIncomeAmount(
            tcFamily familyArg, IAssetRepository assetRepo, ISettingsRepository settingsRepo)
        {
            decimal totalAssetIncomeAmount = 0;            
            decimal totalAssetValue = 0;
            decimal totalAssetIncome = 0;            

            //1. Get total assets for the family
            IEnumerable<tcAsset> eligibleAssets = 
                new TotalAssetCalculationStandard().ReturnTotalEligibleAssetsForFamily(familyArg, assetRepo);

            //2. Snag the total asset income
            totalAssetIncome = eligibleAssets.Sum(asset => (asset.AnnualIncome ?? 0));

            //3. Determine if asset value meets the HUD threshold            
            totalAssetIncomeAmount = CalculateTotalAssetAmountConsideringThreshold(
                totalAssetValue, totalAssetIncome, settingsRepo);

            return totalAssetIncomeAmount;
        }


        private decimal CalculateTotalAssetAmountConsideringThreshold(
            decimal totalAssetValue, decimal totalAssetIncome, ISettingsRepository settingsRepo)
        {
            decimal totalAssetIncomeAmount = 0;

            if (totalAssetValue > settingsRepo.GetThresholdValue()) //if we're greater than the threshold, we'll compare income verse overall asset value
            {
                //calculate imputed income with the HUD passbook rate
                decimal imputedIncome = totalAssetValue * settingsRepo.GetHUDPassbookRate() ?? 0;

                if (imputedIncome > totalAssetIncome) //take the greater of the imputed verse actual income
                    totalAssetIncomeAmount = imputedIncome;
                else
                    totalAssetIncomeAmount = totalAssetIncome;
            }
            else
            {
                totalAssetIncomeAmount = totalAssetIncome;
            }

            return totalAssetIncomeAmount;
        }
    }
}
