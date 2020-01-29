using System;
using TaxCredit.Core.Models;
using TaxCredit.Infrastructure.Data;
using TaxCredit.Infrastructure.Repositories;
using TaxCredit.Core.Interfaces.UnitOfWork;
using TaxCredit.Core.Interfaces.Repositories;

namespace TaxCredit.Infrastructure.UnitOfWork
{
    public class ComplianceCalculationUnitOfWork : IComplianceCalculationUnitOfWork
    {
        private EliteTaxCreditEntities _dataContext = null;
        private bool disposed = false;

        private IBaseRepository<tcDTFamily> _dtFamilyRepository = null;
        private IBaseRepository<tcDTFamilyMember> _dtfamilyMemberRepository = null;
        private IDTIncomeRepository _dtIncomeRepository = null;
        private IBaseRepository<tcDTIncomeType> _dtIncomeTypeRepository = null;
        private IBaseRepository<tcDTAsset> _dtAssetRepository = null;

        private IIncomeRepository _incomeRepository = null;
        private IFamilyRepository _familyRepository = null;
        private IFamilyMemberRepository _familyMemberRepository = null;
        private IBaseRepository<tcIncomeType> _incomeTypeRepository = null;

        private IBaseRepository<tcFamilyMemberStatu> _familyMemberStatusRepository = null;
        private IBaseRepository<tcGender> _genderRepository = null;
        private IBaseRepository<tcStudentStatu> _studentStatusRepository = null;
        private IBaseRepository<tcSpecialStatu> _specialStatusRepository = null;
        private IAssetRepository _assetRepository = null;
        private ISettingsRepository _settingsRepository = null;
        private IDTIncomeTypeRepository _dtIncomeTypeRespository = null;
        



        public ComplianceCalculationUnitOfWork()
        {
            _dataContext = new EliteTaxCreditEntities();
        }

        public ISettingsRepository SettingsRepository
        {
            get
            {
                if (_settingsRepository == null)
                    _settingsRepository = new tcSettingsRepository(_dataContext);

                return _settingsRepository;
            }
        }

        public IBaseRepository<tcDTAsset> DTAssetRepository
        {
            get
            {
                if (_dtAssetRepository == null)
                    _dtAssetRepository = new tcBaseRepository<tcDTAsset>(_dataContext);

                return _dtAssetRepository;
            }
        }

        public IAssetRepository AssetRepository
        {
            get
            {
                if (_assetRepository == null)
                    _assetRepository = new tcAssetRepository(_dataContext);

                return _assetRepository;
            }
        }

        public IBaseRepository<tcFamilyMemberStatu> FamilyMemberStatusRepository
        {
            get
            {
                if (_familyMemberStatusRepository == null)
                    _familyMemberStatusRepository = new tcBaseRepository<tcFamilyMemberStatu>(_dataContext);

                return _familyMemberStatusRepository;
            }
        }

        public IBaseRepository<tcGender> GenderRepository
        {
            get
            {
                if (_genderRepository == null)
                    _genderRepository = new tcBaseRepository<tcGender>(_dataContext);

                return _genderRepository;
            }
        }

        public IBaseRepository<tcStudentStatu> StudentStatusRepository
        {
            get
            {
                if (_studentStatusRepository == null)
                    _studentStatusRepository = new tcBaseRepository<tcStudentStatu>(_dataContext);

                return _studentStatusRepository;
            }
        }

        public IBaseRepository<tcSpecialStatu> SpecialStatusRepository
        {
            get
            {
                if (_specialStatusRepository == null)
                    _specialStatusRepository = new tcBaseRepository<tcSpecialStatu>(_dataContext);

                return _specialStatusRepository;
            }
        }

        public IFamilyMemberRepository FamilyMemberRepository
        {
            get
            {
                if (_familyMemberRepository == null)
                    _familyMemberRepository = new tcFamilyMemberRepository(_dataContext);

                return _familyMemberRepository;
            }
        }

        public IFamilyRepository FamilyRepository
        {
            get
            {
                if (_familyRepository == null)
                    _familyRepository = new tcFamilyRepository(_dataContext);

                return _familyRepository;
            }
        }

        public IDTIncomeRepository DTIncomeRepository
        {
            get
            {
                if (_dtIncomeRepository == null)
                    _dtIncomeRepository = new tcDTIncomeRepository(_dataContext);

                return _dtIncomeRepository;
            }
        }

        public IDTIncomeTypeRepository DTIncomeTypeRepository
        {
            get
            {
                if (_dtIncomeTypeRespository == null)
                    _dtIncomeTypeRespository = new tcDTIncomeTypeRepository(_dataContext);

                return _dtIncomeTypeRespository;
            }
        }

        public IBaseRepository<tcDTFamily> DTFamilyRepository
        {
            get
            {
                if (_dtFamilyRepository == null)
                    _dtFamilyRepository = new tcBaseRepository<tcDTFamily>(_dataContext);

                return _dtFamilyRepository;
            }
        }

        public IBaseRepository<tcDTFamilyMember> DTFamilyMemberRepository
        {
            get
            {
                if (_dtfamilyMemberRepository == null)
                    _dtfamilyMemberRepository = new tcBaseRepository<tcDTFamilyMember>(_dataContext);

                return _dtfamilyMemberRepository;
            }
        }

        public IBaseRepository<tcDTIncomeType> DTIncomeTypeRespository
        {
            get
            {
                if (_dtIncomeTypeRepository == null)
                    _dtIncomeTypeRepository = new tcBaseRepository<tcDTIncomeType>(_dataContext);

                return _dtIncomeTypeRepository;
            }
        }

        public IIncomeRepository IncomeRepository
        {
            get
            {
                if (_incomeRepository == null)
                    _incomeRepository = new tcIncomeRepository(_dataContext);

                return _incomeRepository;
            }
        }

        public IBaseRepository<tcIncomeType> IncomeTypeRepository
        {
            get
            {
                if (_incomeTypeRepository == null)
                    _incomeTypeRepository = new tcBaseRepository<tcIncomeType>(_dataContext);

                return _incomeTypeRepository;
            }
        }

       
        public void Save()
        {
            _dataContext.SaveChanges();
        }


        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
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
