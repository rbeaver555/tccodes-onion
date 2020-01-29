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
    /// <summary>
    /// When testing total assets you want to be aware of a few scenarios:
    /// 1. To exclued the assets of non-eligible members
    /// 2. To take withdrawl penalties into account
    /// 3. To take asset income as well as asset value into account (HUD Passbook Rate on the Value)
    /// 4. When the total asset value is greater than 5000, you take the greater of asset income or passbook rate
    /// </summary>
    [TestClass]
    public class GrossIncomeCalculationStandardTest
    {

        [TestInitialize]
        public void Initialize()
        {

        }


        /// <summary>
        /// Standard test, let's just ensure that the count is working on some level...
        /// </summary>
        [TestMethod]
        public void NoIncomeAssociatedWithAsset_ShouldCalculateToZero()
        {
            //Arrange is happening in the initialize method...                             
            IGrossAssetIncomeAmountCalculation standardAssetCalculation = new GrossAssetIncomeAmountCalculationStandard();
            var mockAssetRepository = new Mock<IAssetRepository>();
            var mockSettingsRepository = new Mock<ISettingsRepository>();
            Mock<tcFamily> stubFamily = new Mock<tcFamily>();

            mockSettingsRepository
                .Setup(repo => repo.GetHUDPassbookRate())
                .Returns(() => .05m);

            mockSettingsRepository
                .Setup(repo => repo.GetThresholdValue())
                .Returns(() => 5000m);


            mockAssetRepository
            .Setup(repo => repo.GetAssetsByFamily(It.IsAny<int>()))
            .Returns(() =>
                new List<tcAsset>()
                {
                        new tcAsset
                        {
                           Value = 1000,
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
            decimal grossAssetIncomeAmount = standardAssetCalculation.CalculateTotalAssetIncomeAmount(stubFamily.Object, mockAssetRepository.Object, mockSettingsRepository.Object);


            //Assert            
            Assert.IsTrue(grossAssetIncomeAmount == 0m);
        }



        [TestMethod]
        public void ExcludingLiveInAideAsset_ShouldCalculateTo100()
        {
            //Arrange is happening in the initialize method...                             
            IGrossAssetIncomeAmountCalculation standardAssetCalculation = new GrossAssetIncomeAmountCalculationStandard();
            var mockAssetRepository = new Mock<IAssetRepository>();
            var mockSettingsRepository = new Mock<ISettingsRepository>();
            Mock<tcFamily> stubFamily = new Mock<tcFamily>();

            mockSettingsRepository
                .Setup(repo => repo.GetHUDPassbookRate())
                .Returns(() => .05m);

            mockSettingsRepository
                .Setup(repo => repo.GetThresholdValue())
                .Returns(() => 5000m);


            mockAssetRepository
            .Setup(repo => repo.GetAssetsByFamily(It.IsAny<int>()))
            .Returns(() =>
                new List<tcAsset>()
                {
                        new tcAsset
                        {
                           Value = 1000,
                            IsActive = true,
                             tcFamilyMember = new tcFamilyMember
                             {
                                 tcFamilyMemberStatu = new tcFamilyMemberStatu{ FamilyMemberStatus = "Head"},
                                 IsActive = true
                             },
                             AnnualIncome = 100,
                             WithdrawlPenalty = 0
                        },
                        new tcAsset
                        {
                           Value = 1000,
                            IsActive = true,
                             tcFamilyMember = new tcFamilyMember
                             {
                                 tcFamilyMemberStatu = new tcFamilyMemberStatu{ FamilyMemberStatus = "Live-In Aide"},
                                 IsActive = true
                             },
                             AnnualIncome = 100,
                             WithdrawlPenalty = 0
                        },

                });


            //Act
            decimal grossAssetIncomeAmount = standardAssetCalculation.CalculateTotalAssetIncomeAmount(stubFamily.Object, mockAssetRepository.Object, mockSettingsRepository.Object);


            //Assert            
            Assert.IsTrue(grossAssetIncomeAmount == 100m);
        }

        public void ExcludingNonEligibleFamilyMember_ShouldCalculateTo100()
        {
            //Arrange is happening in the initialize method...                             
            IGrossAssetIncomeAmountCalculation standardAssetCalculation = new GrossAssetIncomeAmountCalculationStandard();
            var mockAssetRepository = new Mock<IAssetRepository>();
            var mockSettingsRepository = new Mock<ISettingsRepository>();
            Mock<tcFamily> stubFamily = new Mock<tcFamily>();

            mockSettingsRepository
                .Setup(repo => repo.GetHUDPassbookRate())
                .Returns(() => .05m);

            mockSettingsRepository
                .Setup(repo => repo.GetThresholdValue())
                .Returns(() => 5000m);


            mockAssetRepository
            .Setup(repo => repo.GetAssetsByFamily(It.IsAny<int>()))
            .Returns(() =>
                new List<tcAsset>()
                {
                        new tcAsset
                        {
                           Value = 1000,
                            IsActive = true,
                             tcFamilyMember = new tcFamilyMember
                             {
                                 tcFamilyMemberStatu = new tcFamilyMemberStatu{ FamilyMemberStatus = "Head"},
                                 IsActive = true
                             },
                             AnnualIncome = 100,
                             WithdrawlPenalty = 0
                        },
                        new tcAsset
                        {
                           Value = 1000,
                            IsActive = true,
                             tcFamilyMember = new tcFamilyMember
                             {
                                 tcFamilyMemberStatu = new tcFamilyMemberStatu{ FamilyMemberStatus = "Non-Eligible Family Member"},
                                 IsActive = true
                             },
                             AnnualIncome = 100,
                             WithdrawlPenalty = 0
                        },

                });


            //Act
            decimal grossAssetIncomeAmount = standardAssetCalculation.CalculateTotalAssetIncomeAmount(stubFamily.Object, mockAssetRepository.Object, mockSettingsRepository.Object);


            //Assert            
            Assert.IsTrue(grossAssetIncomeAmount == 100m);
        }

        /// <summary>
        /// Standard test, let's just ensure that the count is working on some level...
        /// </summary>
        [TestMethod]
        public void ConsideringWithdrawlPenaltyAndThreshold_ShouldCalculateTo100()
        {
            //Arrange is happening in the initialize method...                             
            IGrossAssetIncomeAmountCalculation standardAssetCalculation = new GrossAssetIncomeAmountCalculationStandard();
            var mockAssetRepository = new Mock<IAssetRepository>();
            var mockSettingsRepository = new Mock<ISettingsRepository>();
            Mock<tcFamily> stubFamily = new Mock<tcFamily>();

            mockSettingsRepository
                .Setup(repo => repo.GetHUDPassbookRate())
                .Returns(() => .05m);

            mockSettingsRepository
                .Setup(repo => repo.GetThresholdValue())
                .Returns(() => 5000m);


            mockAssetRepository
            .Setup(repo => repo.GetAssetsByFamily(It.IsAny<int>()))
            .Returns(() =>
                new List<tcAsset>()
                {
                        new tcAsset
                        {
                           Value = 5025,
                            IsActive = true,
                             tcFamilyMember = new tcFamilyMember
                             {
                                 tcFamilyMemberStatu = new tcFamilyMemberStatu{ FamilyMemberStatus = "Head"},
                                 IsActive = true
                             },
                             AnnualIncome = 100,
                             WithdrawlPenalty = 50
                        }
                });


            //Act
            decimal grossAssetIncomeAmount = standardAssetCalculation.CalculateTotalAssetIncomeAmount(stubFamily.Object, mockAssetRepository.Object, mockSettingsRepository.Object);


            //Assert            
            Assert.IsTrue(grossAssetIncomeAmount == 100m);
        }

     



        /// <summary>
        /// Standard test, let's just ensure that the count is working on some level...
        /// </summary>
        [TestMethod]
        public void AssetIncomeIsHigherThanThreshold_ShouldCalculateTo300()
        {
            //Arrange is happening in the initialize method...                             
            IGrossAssetIncomeAmountCalculation standardAssetCalculation = new GrossAssetIncomeAmountCalculationStandard();
            var mockAssetRepository = new Mock<IAssetRepository>();
            var mockSettingsRepository = new Mock<ISettingsRepository>();
            Mock<tcFamily> stubFamily = new Mock<tcFamily>();

            mockSettingsRepository
                .Setup(repo => repo.GetHUDPassbookRate())
                .Returns(() => .05m);

            mockSettingsRepository
                .Setup(repo => repo.GetThresholdValue())
                .Returns(() => 5000m);


            mockAssetRepository
            .Setup(repo => repo.GetAssetsByFamily(It.IsAny<int>()))
            .Returns(() =>
                new List<tcAsset>()
                {
                        new tcAsset
                        {
                           Value = 5100,
                            IsActive = true,
                             tcFamilyMember = new tcFamilyMember
                             {
                                 tcFamilyMemberStatu = new tcFamilyMemberStatu{ FamilyMemberStatus = "Head"},
                                 IsActive = true
                             },
                             AnnualIncome = 300,
                             WithdrawlPenalty = 50
                        }
                });


            //Act
            decimal grossAssetIncomeAmount = standardAssetCalculation.CalculateTotalAssetIncomeAmount(stubFamily.Object, mockAssetRepository.Object, mockSettingsRepository.Object);


            //Assert            
            Assert.IsTrue(grossAssetIncomeAmount == 300m);
        }


      

    }
}
