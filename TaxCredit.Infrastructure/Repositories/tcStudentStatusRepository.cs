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
    public class tcStudentStatusRepository : tcBaseRepository<tcStudentStatu>, IStudentStatusRepository
    {

        public tcStudentStatusRepository(EliteTaxCreditEntities context) : base(context)
        {
        }

        public tcStudentStatu FindByDescription(string description)
        {
            tcStudentStatu studentStatus = null;

            studentStatus = _dataContext.tcStudentStatus.SingleOrDefault(status =>
                status.StudentStatus.Trim().ToLower() == description.Trim().ToLower());

            return studentStatus;
        }



        public List<tcStudentStatu> GetAll()
        {
            List<tcStudentStatu> studentStatuses = null;

            studentStatuses = _dataContext.tcStudentStatus.ToList();

            return studentStatuses;
        }
    }
}
