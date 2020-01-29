using System;
using TaxCredit.Core.Models;
using TaxCredit.Infrastructure.Data;
using TaxCredit.Infrastructure.Repositories;



namespace TaxCredit.Infrastructure.UnitOfWork
{
    public class CertificationTransferUnitOfWork : IDisposable
    {
        private EliteTaxCreditEntities dataContext = new EliteTaxCreditEntities();
        private bool disposed = false;

        private tcBaseRepository<tcDTFamily> _dtFamilyRepository;
        private tcBaseRepository<tcDTFamilyMember> _dtFamilyMemberRepository;
        private tcDTIncomeRepository _dtIncomeRepository;
        private tcBaseRepository<tcDTIncomeType> _dtIncomeTypeRepository;
        private tcBaseRepository<tcDTAsset> _dtAssetRepository;

        private tcIncomeRepository _incomeRepository;
        private tcFamilyRepository _familyRepository;
        private tcFamilyMemberRepository _familyMemberRepository;
        private tcBaseRepository<tcIncomeType> _incomeTypeRepository;

        private tcBaseRepository<tcFamilyMemberStatu> _familyMemberStatusRepository;
        private tcBaseRepository<tcGender> _genderRepository;
        private tcBaseRepository<tcStudentStatu> _studentStatusRepository;
        private tcBaseRepository<tcSpecialStatu> _specialStatusRepository;
        private tcBaseRepository<tcAsset> _assetRepository;

        private tcBaseRepository<tcSetting> _settingRepository;



        public tcBaseRepository<tcDTAsset> DTAssetRepository
        {
            get
            {
                if (_dtAssetRepository == null)
                    _dtAssetRepository = new tcBaseRepository<tcDTAsset>(dataContext);

                return _dtAssetRepository;
            }
        }

        public tcBaseRepository<tcAsset> AssetRepository
        {
            get
            {
                if (_assetRepository == null)
                    _assetRepository = new tcBaseRepository<tcAsset>(dataContext);

                return _assetRepository;
            }
        }

        public tcBaseRepository<tcSetting> SettingRepository
        {
            get
            {
                if (_settingRepository == null)
                    _settingRepository = new tcBaseRepository<tcSetting>(dataContext);

                return _settingRepository;
            }
        }

        public tcBaseRepository<tcFamilyMemberStatu> FamilyMemberStatusRepository
        {
            get
            {
                if (_familyMemberStatusRepository == null)
                    _familyMemberStatusRepository = new tcBaseRepository<tcFamilyMemberStatu>(dataContext);

                return _familyMemberStatusRepository;
            }
        }

        public tcBaseRepository<tcGender> GenderRepository
        {
            get
            {
                if (_genderRepository == null)
                    _genderRepository = new tcBaseRepository<tcGender>(dataContext);

                return _genderRepository;
            }
        }

        public tcBaseRepository<tcStudentStatu> StudentStatusRepository
        {
            get
            {
                if (_studentStatusRepository == null)
                    _studentStatusRepository = new tcBaseRepository<tcStudentStatu>(dataContext);

                return _studentStatusRepository;
            }
        }

        public tcBaseRepository<tcSpecialStatu> SpecialStatusRepository
        {
            get
            {
                if (_specialStatusRepository == null)
                    _specialStatusRepository = new tcBaseRepository<tcSpecialStatu>(dataContext);

                return _specialStatusRepository;
            }
        }

        public tcBaseRepository<tcDTFamilyMember> DTFamilyMemberRepository
        {
            get
            {
                if (_dtFamilyMemberRepository == null)
                    _dtFamilyMemberRepository = new tcBaseRepository<tcDTFamilyMember>(dataContext);

                return _dtFamilyMemberRepository;
            }
        }

        public tcFamilyMemberRepository FamilyMemberRepository
        {
            get
            {
                if (_familyMemberRepository == null)
                    _familyMemberRepository = new tcFamilyMemberRepository(dataContext);

                return _familyMemberRepository;
            }
        }

        public tcFamilyRepository FamilyRepository
        {
            get
            {
                if (_familyRepository == null)
                    _familyRepository = new tcFamilyRepository(dataContext);

                return _familyRepository;
            }
        }

        public tcDTIncomeRepository DTIncomeRepository
        {
            get
            {
                if (_dtIncomeRepository == null)
                    _dtIncomeRepository = new tcDTIncomeRepository(dataContext);

                return _dtIncomeRepository;
            }
        }

        public tcBaseRepository<tcDTFamily> DTFamilyRepository
        {
            get
            {
                if (_dtFamilyRepository == null)
                    _dtFamilyRepository = new tcBaseRepository<tcDTFamily>(dataContext);

                return _dtFamilyRepository;
            }
        }

        public tcBaseRepository<tcDTIncomeType> DTIncomeTypeRespository
        {
            get
            {
                if (_dtIncomeTypeRepository == null)
                    _dtIncomeTypeRepository = new tcBaseRepository<tcDTIncomeType>(dataContext);

                return _dtIncomeTypeRepository;
            }
        }

        public tcIncomeRepository IncomeRepository
        {
            get
            {
                if (_incomeRepository == null)
                    _incomeRepository = new tcIncomeRepository(dataContext);

                return _incomeRepository;
            }
        }

        public tcBaseRepository<tcIncomeType> IncomeTypeRepository
        {
            get
            {
                if (_incomeTypeRepository == null)
                    _incomeTypeRepository = new tcBaseRepository<tcIncomeType>(dataContext);

                return _incomeTypeRepository;
            }
        }

        public void Save()
        {
            dataContext.SaveChanges();
        }


        public virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    dataContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
