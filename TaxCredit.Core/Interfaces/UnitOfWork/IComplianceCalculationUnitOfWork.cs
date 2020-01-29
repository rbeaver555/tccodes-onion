using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCredit.Core.Interfaces.Repositories;
using TaxCredit.Core.Models;

namespace TaxCredit.Core.Interfaces.UnitOfWork
{
    public interface IComplianceCalculationUnitOfWork : IDisposable
    {
        IBaseRepository<tcDTAsset> DTAssetRepository { get;}
        IAssetRepository AssetRepository { get;  }
        ISettingsRepository SettingsRepository { get;  }
        IBaseRepository<tcFamilyMemberStatu> FamilyMemberStatusRepository { get;  }
        IBaseRepository<tcGender> GenderRepository { get;  }
        IBaseRepository<tcStudentStatu> StudentStatusRepository { get;  }
        IBaseRepository<tcSpecialStatu> SpecialStatusRepository { get;  }
        IFamilyMemberRepository FamilyMemberRepository { get;  }
        IFamilyRepository FamilyRepository { get;  }
        IDTIncomeRepository DTIncomeRepository { get;  }
        IBaseRepository<tcDTFamily> DTFamilyRepository { get;  }
        IBaseRepository<tcDTIncomeType> DTIncomeTypeRespository { get;  }
        IIncomeRepository IncomeRepository { get;  }
        IBaseRepository<tcIncomeType> IncomeTypeRepository { get;  }
        IBaseRepository<tcDTFamilyMember> DTFamilyMemberRepository { get; }
        IDTIncomeTypeRepository DTIncomeTypeRepository { get; }

        void Save();
        void Dispose(bool disposing);

    }
}
