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
    public class tcDTStudentStatusRepository : tcBaseRepository<tcDTStudentStatu>, IDTStudentStatusRepository
    {

        public tcDTStudentStatusRepository(EliteTaxCreditEntities context) : base(context)
        {
        }


        public tcDTStudentStatu FindByDescription(string description)
        {
            tcDTStudentStatu studentStatus = null;

            studentStatus = _dataContext.tcDTStudentStatus.SingleOrDefault(status =>
                status.StudentStatus.Trim().ToLower() == description.Trim().ToLower());

            return studentStatus;
        }



        public List<tcDTStudentStatu> GetAll()
        {
            List<tcDTStudentStatu> studentStatuses = null;

            studentStatuses = _dataContext.tcDTStudentStatus.ToList();


            return studentStatuses;
        }
    }
}
