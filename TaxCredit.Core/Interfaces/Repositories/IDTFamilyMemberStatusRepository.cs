using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCredit.Core.Models;

namespace TaxCredit.Core.Interfaces.Repositories
{
    public interface IDTFamilyMemberStatusRepository
    {
        List<tcDTFamilyMemberStatu> GetAll();

        tcDTFamilyMemberStatu FindByDescription(string description);

    }
}
