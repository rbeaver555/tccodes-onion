using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCredit.Core.Interfaces.DomainServices;
using TaxCredit.Core.Models;

namespace TaxCredit.Core.DomainServices
{
    public sealed class IncomeFilters : IIncomeFilters
    {

        public IEnumerable<tcIncome> RemoveInEligibleFamilyMemberIncomesFromCollection(IEnumerable<tcIncome> incomes)
        {
            return incomes.Where(income => income.IsActive &&
                                           income.tcFamilyMember.IsActive &&
                                           income.tcFamilyMember.tcFamilyMemberStatu.FamilyMemberStatus.Trim().ToLower() != Constants.FamilyMemberStatus.NonEligibleFamilyMember.Trim().ToLower() &&
                                           income.tcFamilyMember.tcFamilyMemberStatu.FamilyMemberStatus.Trim().ToLower() != Constants.FamilyMemberStatus.LiveInAide.Trim().ToLower());

        }

        public IEnumerable<tcIncome> RemoveEarnedIncomesOfDependentsUnder18(IEnumerable<tcIncome> incomes)
        {
            return incomes.Where(income => !(income.tcFamilyMember.tcFamilyMemberStatu.FamilyMemberStatus.Trim().ToLower() == Constants.FamilyMemberStatus.Dependent.Trim().ToLower() &&
                                    ((income.tcFamilyMember.BirthDate ?? DateTime.Now) > DateTime.Now.AddYears(-18)) &&
                                    (income.tcIncomeType.IncomeType.Trim().ToLower() == Constants.IncomeTypes.EmploymentorWages.Trim().ToLower() ||
                                    income.tcIncomeType.IncomeType.Trim().ToLower() == Constants.IncomeTypes.OtherIncome.Trim().ToLower())));
        }

        public IEnumerable<tcIncome> RetrieveAdultStudentIncome(IEnumerable<tcIncome> incomes)
        {
            return incomes.Where(income => (income.tcFamilyMember.tcFamilyMemberStatu.FamilyMemberStatus.Trim().ToLower() == Constants.FamilyMemberStatus.Dependent.Trim().ToLower() &&
                        ((income.tcFamilyMember.BirthDate ?? DateTime.Now) < DateTime.Now.AddYears(-18)) &&
                        (income.tcFamilyMember.tcStudentStatu != null &&
                        income.tcFamilyMember.tcStudentStatu.StudentStatus.Trim().ToLower() == Constants.StudentsStatusTypes.FullTimeStudent.Trim().ToLower()) &&
                        (income.tcIncomeType.IncomeType.Trim().ToLower() == Constants.IncomeTypes.EmploymentorWages.Trim().ToLower() ||
                        income.tcIncomeType.IncomeType.Trim().ToLower() == Constants.IncomeTypes.OtherIncome.Trim().ToLower())));
        }

    }
}
