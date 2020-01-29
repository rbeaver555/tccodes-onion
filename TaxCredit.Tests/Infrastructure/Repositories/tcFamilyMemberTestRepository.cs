//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using TaxCredit.Core.Interfaces.Repositories;
//using TaxCredit.Core.Models;
//using TaxCredit.Tests.Infrastructure.Repositories.TaxCredit.Infrastructure.Repositories;

//namespace TaxCredit.Tests.Infrastructure.Repositories
//{
//    class tcFamilyMemberTestRepository : tcBaseTestRepository<tcFamilyMember>, IFamilyMemberRepository
//    {
//        public tcFamilyMemberTestRepository() : base()
//        {
//            foreach (var familyMember in GetSeedData())
//                Insert(familyMember);
//        }

//        public static IEnumerable<tcFamilyMember> GetSeedData()
//        {
//            List<tcFamilyMember> returnCollection = new List<tcFamilyMember>();

//            //add members to the test family
//            returnCollection.Add(new tcFamilyMember
//            {
//                FirstName = "Bill",
//                LastName = "Wilson",
//                fkFamily = 1,
//                IsActive = true,
//            });

//            returnCollection.Add(new tcFamilyMember
//            {
//                FirstName = "Jill",
//                LastName = "Wilson",
//                fkFamily = 1,
//                IsActive = true,
//            });

//            returnCollection.Add(new tcFamilyMember
//            {
//                FirstName = "John",
//                LastName = "Wilson",

//                fkFamily = 2,
//                IsActive = true,
//            });

//            returnCollection.Add(new tcFamilyMember
//            {
//                FirstName = "Sallly",
//                LastName = "Wilson",
//                fkFamily = 2,
//                IsActive = true,
//            });

//            returnCollection.Add(new tcFamilyMember
//            {
//                FirstName = "Albert",
//                LastName = "Williams",
//                fkFamily = 3,
//                IsActive = true,
//            });

//            return returnCollection;
//        }

//        public IEnumerable<tcFamilyMember> GetFamilyMembersByFamilyID(int familyID)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
