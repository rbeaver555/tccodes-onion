﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCredit.Core.Models;

namespace TaxCredit.Core.Interfaces.Repositories
{
    public interface IDTIncomeTypeRepository
    {
        List<tcDTIncomeType> GetAll();

        tcDTIncomeType FindByDescription(string description);
    }
}
