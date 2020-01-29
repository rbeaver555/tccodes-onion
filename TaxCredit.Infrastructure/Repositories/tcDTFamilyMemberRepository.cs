//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TaxCredit.Core.Interfaces.Repositories;
//using TaxCredit.Core.Models;
//using TaxCredit.Infrastructure.Data;

//namespace TaxCredit.Infrastructure.Repositories
//{
//    public class tcDTFamilyMemberRepository : tcBaseRepository<tcDTFamilyMember>, IDTFamilyMemberRepository
//    {
//        public tcDTFamilyMemberRepository(EliteTaxCreditEntities context) : 

//        public List<tcDTFamilyMember> GetFamilyMembersByFamily(tcDTFamily tcDTFamily)
//        {
//            List<tcDTFamilyMember> returnValue = null;


//            using (EliteTaxCreditEntities dataContext = new EliteTaxCreditEntities())
//            {
//                returnValue = dataContext.tcDTFamilyMembers.Where(famMem => famMem.fkFamily == tcDTFamily.PK).ToList();
//            }


//            return returnValue;
//        }
//    }
//}
