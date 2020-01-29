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
    public class tcGenderRepository : tcBaseRepository<tcGender>, IGenderRepository
    {

        public tcGenderRepository(EliteTaxCreditEntities context) : base(context)
        {
        }

        public tcGender FindByDescription(string description)
        {
            tcGender genders = null;

            genders = _dataContext.tcGenders.SingleOrDefault(gender =>
                gender.Gender.Trim().ToLower() == description.Trim().ToLower());

            return genders;
        }



        public List<tcGender> GetAll()
        {
            List<tcGender> genders = null;

            genders = _dataContext.tcGenders.ToList();

            return genders;
        }
    }
}
