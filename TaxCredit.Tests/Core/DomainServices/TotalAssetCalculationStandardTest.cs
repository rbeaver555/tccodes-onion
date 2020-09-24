using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCredit.Core.DomainServices;
using TaxCredit.Core.Interfaces.DomainServices;
using TaxCredit.Core.Interfaces.Repositories;
using TaxCredit.Core.Models;
using System.Collections.Generic;
using Moq;

namespace TaxCredit.Tests.Core.DomainServices
{
    [TestClass]
    public class TotalAssetCalculationStandardTest
    {

        //test method
        [TestMethod]
        public void NoSpecialCircumStances_ShouldCalculateto10000()
        {
            //Arrange                       
            ITotalAssetCalculation standardGrossAssetCalculation = new TotalAssetCalculationStandard();
            var mockAssetRepository = new Mock<IAssetRepository>();            
            Mock<tcFamily> stubFamily = new Mock<tcFamily>();

            mockAssetRepository
            .Setup(repo => repo.GetAssetsByFamily(It.IsAny<int>()))
            .Returns(() =>
                new List<tcAsset>()
                {
                        new tcAsset
                        {
                            Value = 10000,
                            IsActive = true,
                            tcFamilyMember = new tcFamilyMember
                            {
                                tcFamilyMemberStatu = new tcFamilyMemberStatu{ FamilyMemberStatus = "Head"},
                                IsActive = true
                            },
                            AnnualIncome = 0,
                            WithdrawlPenalty = 0
                        }
                });

            //Act
            decimal totalAssetAmount = standardGrossAssetCalculation.CalculateTotalAssetAmount(
                stubFamily.Object, mockAssetRepository.Object);

            //Assert            
            Assert.IsTrue(totalAssetAmount == 10000);
        }

        public void MultipleAssets_NoIncome_NoWithdrawl_ShouldCalculateto10000()
        {
            //Arrange                       
           
            //Act
           
            //Assert            
                      
        }
    }
}
