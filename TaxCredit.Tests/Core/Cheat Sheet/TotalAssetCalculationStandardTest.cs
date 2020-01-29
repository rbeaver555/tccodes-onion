using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCredit.Core.DomainServices;
using TaxCredit.Core.Interfaces.DomainServices;
using TaxCredit.Core.Interfaces.Repositories;
using TaxCredit.Core.Models;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
//using System.Data.Entity;
using Moq;

namespace TaxCredit.Tests.Core.Cheat
{
    [TestClass]
    public class TotalAssetCalculationStandardTest
    {
        [TestMethod]
        public void NoSpecialCircumStances_ShouldCalculateto10000()
        {

            //Arrange is happening in the initialize method...                             
            ITotalAssetCalculation standardGrossAssetCalculation = new TotalAssetCalculationStandard();
            var mockAssetRepository = new Mock<IAssetRepository>();
            var mockSettingsRepository = new Mock<ISettingsRepository>();
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
            decimal totalAssetAmount = standardGrossAssetCalculation.CalculateTotalAssetAmount(stubFamily.Object, mockAssetRepository.Object);


            //Assert            
            Assert.IsTrue(totalAssetAmount == 10000m);
        }

        public void MultipleAssets_ShouldCalculateto10000()
        {

            //Arrange is happening in the initialize method...                             
            ITotalAssetCalculation standardGrossAssetCalculation = new TotalAssetCalculationStandard();
            var mockAssetRepository = new Mock<IAssetRepository>();
            var mockSettingsRepository = new Mock<ISettingsRepository>();
            Mock<tcFamily> stubFamily = new Mock<tcFamily>();

            mockAssetRepository
            .Setup(repo => repo.GetAssetsByFamily(It.IsAny<int>()))
            .Returns(() =>
                new List<tcAsset>()
                {
                        new tcAsset
                        {
                           Value = 3000,
                            IsActive = true,
                             tcFamilyMember = new tcFamilyMember
                             {
                                 tcFamilyMemberStatu = new tcFamilyMemberStatu{ FamilyMemberStatus = "Head"},
                                 IsActive = true
                             },
                             AnnualIncome = 0,
                             WithdrawlPenalty = 0
                        },
                        new tcAsset
                        {
                           Value = 3000,
                            IsActive = true,
                             tcFamilyMember = new tcFamilyMember
                             {
                                 tcFamilyMemberStatu = new tcFamilyMemberStatu{ FamilyMemberStatus = "Head"},
                                 IsActive = true
                             },
                             AnnualIncome = 0,
                             WithdrawlPenalty = 0
                        },
                        new tcAsset
                        {
                           Value = 4000,
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
            decimal totalAssetAmount = standardGrossAssetCalculation.CalculateTotalAssetAmount(stubFamily.Object, mockAssetRepository.Object);


            //Assert            
            Assert.IsTrue(totalAssetAmount == 10000m);
        }


        [TestMethod]
        public void WithdrawlPenalty_ShouldCalculateto9000()
        {

            //Arrange is happening in the initialize method...                             
            ITotalAssetCalculation standardGrossAssetCalculation = new TotalAssetCalculationStandard();
            var mockAssetRepository = new Mock<IAssetRepository>();
            var mockSettingsRepository = new Mock<ISettingsRepository>();
            Mock<tcFamily> stubFamily = new Mock<tcFamily>();

            mockSettingsRepository
                .Setup(repo => repo.GetHUDPassbookRate())
                .Returns(() => .05m);

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
                             WithdrawlPenalty = 1000
                        }
                });


            //Act
            decimal totalAssetAmount = standardGrossAssetCalculation.CalculateTotalAssetAmount(stubFamily.Object, mockAssetRepository.Object);


            //Assert            
            Assert.IsTrue(totalAssetAmount == 9000m);
        }


    }   
}
