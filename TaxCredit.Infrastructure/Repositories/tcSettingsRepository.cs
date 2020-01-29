using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using TaxCredit.Core.Interfaces.Repositories;
using TaxCredit.Core.Models;
using TaxCredit.Infrastructure.Data;

namespace TaxCredit.Infrastructure.Repositories
{
    public class tcSettingsRepository : tcBaseRepository<tcSetting>, ISettingsRepository
    {
        public tcSettingsRepository(EliteTaxCreditEntities context) : base(context)
        { }

        public decimal? GetHUDPassbookRate()
        {
            return Get(setting => setting.IsActive == true).Single().HUDPassbookRate;   
        }

        public decimal? GetThresholdValue()
        {
            //TODO: Store this in tcsettings
            return 5000m;
        }
    }
}
