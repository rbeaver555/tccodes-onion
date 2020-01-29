using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCredit.Core.Interfaces.Repositories;
using TaxCredit.Core.Models;
using TaxCredit.Infrastructure.Data;

namespace TaxCredit.Infrastructure.Repositories
{
    public class tcDTFamilyRepository : tcBaseRepository<tcDTFamily>, IDTFamilyRepository
    {
        public tcDTFamilyRepository(EliteTaxCreditEntities context) : base(context)
        {
        }

        public tcDTFamily GetFamilyFromTransactionAndExternalKey(string externalKey, string transactionKey)
        {
            tcDTFamily transferredFamily = null;

            transferredFamily = _dataContext.tcDTFamilies.SingleOrDefault(fam => fam.ExternalKey == externalKey.Trim()
            && fam.TransactionKey == transactionKey.Trim());



            return transferredFamily;
        }
    }
}
