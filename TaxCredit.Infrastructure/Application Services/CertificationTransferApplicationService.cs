using System;
using System.Collections.Generic;
using System.Linq;
using TaxCredit.Core.Interfaces.Services;
using TaxCredit.Core.Models;
using TaxCredit.Infrastructure.UnitOfWork;

namespace TaxCredit.Infrastructure.ApplicantionServices
{
    public class CertificationTransferApplicationService : ITransferService
    {
        CertificationTransferUnitOfWork _uow = null;

        private CertificationTransferApplicationService()
        {
        }


        /// <summary>
        /// Pass in loosely coupled versions of the repositories, later to be altered with unity
        /// </summary>
        /// <param name="dtFamilyRepository"></param>
        /// <param name="familyRepository"></param>
        public CertificationTransferApplicationService(CertificationTransferUnitOfWork unitOfWorkTransfer)
        {
            _uow = unitOfWorkTransfer;
        }
        
        /// <summary>
        /// This method transfers all certification data for later calls
        /// </summary>
        /// <param name="externalKey">The external primary key of the family</param>
        /// <param name="transactionKey">The key for a particular transaction (you may have had several calls against one family)</param>
        /// <param name="effectiveDate">The date this transaction is effective for, compliance may vary based on this date.</param>
        /// <returns></returns>
        public bool TransferDataForEligibilityCall(string externalKey, string transactionKey, DateTime effectiveDate)
        {
            bool returnValue = false;

            try
            {
                //get the dt family                
                tcDTFamily tcDTFamily = _uow.DTFamilyRepository.Get(filter: f => f.ExternalKey == externalKey && f.TransactionKey == transactionKey).Single();

                //transfer the family
                tcFamily family = TransferDTFamilyToTCFamily(_uow, tcDTFamily, effectiveDate, externalKey, transactionKey);


                //get the dtfamilymembers                
                IEnumerable<tcDTFamilyMember> dtFamilyMembers = _uow.DTFamilyMemberRepository.Get(filter: f => f.fkFamily == tcDTFamily.PK);


                //transfer the family members
                IEnumerable<tcFamilyMember> tcFamilyMembers = TransferDTFamilyMemberInfoToTCFamilyMemberInfo(_uow, dtFamilyMembers, family, tcDTFamily, transactionKey);

          
                _uow.Save();



                returnValue = true;

                return returnValue;
            }
            finally
            {
                _uow.Dispose();
            }
        }
       

        /// <summary>
        /// This method is reponsible for transferring the family from data transfer tables to the tax credit tables. Afterwards we'll delete the family
        /// from the dt tables to keep them clean. The tables are meant to be transactional.
        /// 
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="tcDTFamily"></param>
        /// <param name="effectiveDate"></param>
        /// <param name="externalKey"></param>
        /// <param name="transactionKey"></param>
        /// <returns></returns>
        private tcFamily TransferDTFamilyToTCFamily(CertificationTransferUnitOfWork uow, tcDTFamily tcDTFamily, DateTime effectiveDate, string externalKey, string transactionKey)
        {
            tcFamily newFamily = new tcFamily
            {
                EffectiveDate = effectiveDate,
                IsActive = true,
                IsFullTimeResidentialWorker = tcDTFamily.IsFullTimeResidentialWorker,
                ExternalKey = externalKey,
                transactionKey = transactionKey
            };

            //insert the family to the tc family            
            uow.FamilyRepository.Insert(newFamily);

            //remove the family from dt
            //uow.DTFamilyRepository.Delete(tcDTFamily.PK);

            return newFamily;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="dtFamilyMembers"></param>
        /// <param name="tcFamily"></param>
        /// <param name="tcDTFamily"></param>
        /// <param name="transactionKey"></param>
        /// <returns></returns>
        private IEnumerable<tcFamilyMember> TransferDTFamilyMemberInfoToTCFamilyMemberInfo(CertificationTransferUnitOfWork uow, IEnumerable<tcDTFamilyMember> dtFamilyMembers, tcFamily tcFamily, tcDTFamily tcDTFamily, string transactionKey)
        {
            tcFamilyMember newMember = null;


            foreach (tcDTFamilyMember dtMember in dtFamilyMembers)
            {

                newMember = new tcFamilyMember
                {
                    fkFamily = tcFamily.PK,
                    FirstName = dtMember.FirstName.Trim(),
                    LastName = dtMember.LastName.Trim(),
                    SSN = dtMember.SSN.Trim(),
                    MiddleInitial = dtMember.MiddleInitial.Trim(),
                    BirthDate = dtMember.BirthDate,
                    ExternalKey = dtMember.ExternalKey,
                    transactionKey = transactionKey,

                    fkFamilyMemberStatus = uow.FamilyMemberStatusRepository.Get(filter: s => s.FamilyMemberStatus.Trim().ToLower() ==
                        dtMember.tcDTFamilyMemberStatu.FamilyMemberStatus.Trim().ToLower() && s.IsActive).Single().PK,

                    fkGender = (dtMember.Gender.ToLower().Trim() == "m" ? uow.GenderRepository.Get(filter: gen => gen.Gender.Trim().ToLower() == "male" && gen.IsActive).Single()
                        : uow.GenderRepository.Get(filter: gen => gen.Gender.Trim().ToLower() != "female" && gen.IsActive).Single()).PK,

                    IsActive = true
                };

                //if they have a student status, let's hunt down the appropriate one and assign it to the family member                
                if (dtMember.tcDTStudentStatu != null)
                {
                    newMember.fkStudentStatus = uow.StudentStatusRepository.Get(filter: s => s.StudentStatus.Trim().ToLower()
                    == dtMember.tcDTStudentStatu.StudentStatus.Trim().ToLower()).Single().PK;
                }

                //apply special status's for the members                
                if (dtMember.tcDTSpecialStatu != null)
                {
                    newMember.fkSpecialStatus = uow.SpecialStatusRepository.Get(filter: s => s.SpecialStatus.Trim().ToLower()
                    == dtMember.tcDTSpecialStatu.SpecialStatus.Trim().ToLower()).Single().PK;

                }

                //transfer this members asset information
                TransferDTAssetsToTCAssets(uow, dtMember, newMember);

                //transfer this members income information
                TransferDTIncomesToTCIncomes(uow, dtMember, newMember);

                //add the family member to our context for later saving
                uow.FamilyMemberRepository.Insert(newMember);

                //remove the family member
                //uow.DTFamilyMemberRepository.Delete(dtMember.PK);
            }


            return uow.FamilyMemberRepository.InternalCollection;
        }


        public IEnumerable<tcAsset> TransferDTAssetsToTCAssets(CertificationTransferUnitOfWork uow, tcDTFamilyMember dtFamilyMember, tcFamilyMember familyMember)
        {

            tcAsset newAsset = null;

            foreach (tcDTAsset dtAsset in dtFamilyMember.tcDTAssets)
            {
                newAsset = new tcAsset
                {
                    tcFamilyMember = familyMember,
                    AssetDescription = dtAsset.AssetDescription,
                    ExternalKey = dtAsset.ExternalKey,
                    AnnualIncome = dtAsset.AnnualIncome,
                    Value = dtAsset.Value,
                    WithdrawlPenalty = dtAsset.WithdrawlPenalty
                };

                uow.AssetRepository.Insert(newAsset);

                //remove the dt assets
                //uow.DTAssetRepository.Delete(dtAsset.PK);
            }

            return uow.AssetRepository.InternalCollection;
        }

        public IEnumerable<tcIncome> TransferDTIncomesToTCIncomes(CertificationTransferUnitOfWork uow, tcDTFamilyMember dtFamilyMember, tcFamilyMember familyMember)
        {
            tcIncome newIncome = null;

            foreach (tcDTIncome dtIncome in dtFamilyMember.tcDTIncomes)
            {
                newIncome = new tcIncome
                {
                    tcFamilyMember = familyMember,
                    IncomeDescription = dtIncome.IncomeDescription,
                    ExternalKey = dtIncome.ExternalKey,
                    YearlyIncomeAmount = dtIncome.YearlyIncomeAmount,
                    tcIncomeType = uow.IncomeTypeRepository.Get(t => t.IncomeType.Trim().ToLower() == dtIncome.tcDTIncomeType.IncomeType.Trim().ToLower()
                    && t.IsActive).SingleOrDefault(),
                    IsActive = true
                };

                uow.IncomeRepository.Insert(newIncome);

                //remove the income records
                //uow.IncomeRepository.Delete(newIncome.PK);
            }


            return uow.IncomeRepository.InternalCollection;
        }





    }
}
