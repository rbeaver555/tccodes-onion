using System.Collections.Generic;
using System.Linq;
using TaxCredit.Core.Interfaces.DomainServices;
using TaxCredit.Core.Interfaces.Repositories;
using TaxCredit.Core.Models;

namespace TaxCredit.Core.DomainServices
{
    public class GrossIncomeCalculationStandard : IGrossIncomeCalculation
    {
        public decimal CalculateGrossNonAssetIncomeAmount(tcFamily familyArg, IIncomeRepository incomeRepo)
        {
            IncomeFilters incomeFilter = new IncomeFilters();
            decimal grossNonAssetIncomeAmount = 0;

            //1. Pull all the available incomes related to the family
            IEnumerable<tcIncome> incomes = incomeRepo.GetIncomesByFamily(familyArg.PK);

            //2. Filter out inactive incomes
            incomes = RemoveInactiveIncomesFromCollection(incomes);

            //2. Filter out the incomes of ineligible family members
            incomes = incomeFilter.RemoveInEligibleFamilyMemberIncomesFromCollection(incomes);

            //3. Remove earned income of dependents under the age of 18
            incomes = incomeFilter.RemoveEarnedIncomesOfDependentsUnder18(incomes);

            //4. Split full time student earned income over the age of 18 from the group, who are dependents, they have a 480 dollar cap per person
            IEnumerable<tcIncome> studentIncomes = incomeFilter.RetrieveAdultStudentIncome(incomes);

            //now calculate the earned income with 480 cap
            decimal totalStudentEarnedIncome = CalculateEarnedIncomeForAdultStudents(studentIncomes, 480); //TODO: Change 480 to be a setting

            //5. Gather remaining family member incomes
            IEnumerable<tcIncome> standardIncomes = incomes.Where(
                income => !studentIncomes.Select(x => x.PK).Contains(income.PK));

            //Calculate total unearned and earned incomes for the remainder of the family
            decimal totalStandardIncome = standardIncomes.Sum(i => i.YearlyIncomeAmount);

            //add the two together to get total family grossnonassetincome
            grossNonAssetIncomeAmount = CalculateGrossNonAssetIncome(
                totalStudentEarnedIncome, totalStandardIncome);

            return grossNonAssetIncomeAmount;
        }

        internal IEnumerable<tcIncome> RemoveInactiveIncomesFromCollection(IEnumerable<tcIncome> incomes)
        {
            return incomes.Where(income => income.IsActive == true);
        }

        internal decimal CalculateEarnedIncomeForAdultStudents(
            IEnumerable<tcIncome> adultStudentIncomes, decimal incomeCapThreshold)
        {
            return adultStudentIncomes.Sum(
                i => (i.YearlyIncomeAmount > incomeCapThreshold ? incomeCapThreshold : i.YearlyIncomeAmount));
        }

        internal decimal CalculateGrossNonAssetIncome(decimal totalStudentIncome, decimal totalNonStudentIncome)
        {
            return totalStudentIncome + totalNonStudentIncome;
        }

    }
}
