using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCredit.Core.DomainServices
{
    internal class Regex
    {
        // regex to match a valid email address

        public const string EmailRegex = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1}|2[0-4]{1}|25[0-5]{1})\.){3}"
            + @"([0-1]?[0-9]{1}|2[0-4]{1}|25[0-5]{1})|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";


        private void RegexTest()
        {
            // test the regex
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(EmailRegex);
            string email = "john@yahoo.com";
            if (regex.IsMatch(email))
            {
                Console.WriteLine("Valid email address");
            }
            else
            {
                Console.WriteLine("Invalid email address");
            }
        }



    }
}
