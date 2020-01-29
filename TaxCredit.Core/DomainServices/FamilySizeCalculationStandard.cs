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
    public class FamilySizeCalculationStandard : IFamilySizeCalculation
    {         

        /// <summary>
        /// This method calcualtes the overall family member size in the standard IRS way. All members who have an eligible status and are currently marked as isactive. It's imporant to realize
        /// that live in aide's will not be counted in the family size nor eligibility, but should be utilized for bedroom size calculations.
        /// </summary>
        /// <param name="familyArg"></param>
        /// <param name="familyMemberRepo"></param>
        /// <returns></returns>
        public int CalculateFamilySize(tcFamily familyArg, IFamilyMemberRepository familyMemberRepo)
        {
            int familyMemberCount = 0;

            var familyMembers = familyMemberRepo.GetFamilyMembersByFamilyID(familyArg.PK);

            familyMemberCount = (from fm in familyMembers
                                 where
                                    fm.IsActive == true &&
                                    fm.tcFamilyMemberStatu != null &&
                                    fm.tcFamilyMemberStatu.FamilyMemberStatus.Trim().ToLower() != Constants.FamilyMemberStatus.NonEligibleFamilyMember.Trim().ToLower() && //let's ignore non eligible members
                                    fm.tcFamilyMemberStatu.FamilyMemberStatus.Trim().ToLower() != Constants.FamilyMemberStatus.LiveInAide.Trim().ToLower() //we also don't utilize the live in aides,
                                 select fm).Count();
          
            return familyMemberCount;
        }

    }
}
