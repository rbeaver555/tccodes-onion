using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCredit.Core.Models;

namespace TaxCredit.Core.Interfaces.Repositories
{
    public interface ISpecialStatusRepository
    {
        List<tcSpecialStatu> GetAll();

        tcSpecialStatu FindByDescription(string description);
    }
}
