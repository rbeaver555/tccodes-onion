using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCredit.Core.DomainServices
{
    public sealed class Constants
    {

        public static class FamilyMemberStatus
        {
            public const string Head = "Head";
            public const string Spouse = "Spouse";
            public const string Co_Head = "Co-Head";
            public const string EligibleFamilyMember = "Eligible Family Member";
            public const string Dependent = "Dependent";
            public const string NonEligibleFamilyMember = "Non-Eligible Family Member";
            public const string LiveInAide = "Live-In Aide";
        }



        public static class StudentsStatusTypes
        {
            public const string FullTimeStudent = "Full-Time Student";
            public const string PartTimeStudent = "Part-Time Student";
            public const string Non_Student = "Non-Student";
        }

        public static class IncomeTypes
        {
            public const string EmploymentorWages = "Employment or Wages";
            public const string SocialSecurityorPension = "Social Security/Pension";
            public const string PublicAssistance = "Public Assistance";
            public const string OtherIncome = "Other Income";

        }

        public static class GenderTypes
        {
            public const string MALE = "M";
            public const string FEMALE = "F";
        }

        public static class MemberEligibilityCode
        {
            public const string EN = "EN";
            public const string EC = "EC";

        }

        public static class SpecialStatusCode
        {
            public const string ONE = "1";
            public const string TWO = "2";
            public const string THREE = "3";
            public const string FOUR = "4";
        }

        //public static class MinimumSetAsideTypeCode
        //{
        //    public const string A = "A";
        //    public const string B = "B";
        //    public const string C = "C";
        //    public const string D = "D";
        //    public const string E = "E";

        //    public class MinimunSetAsideType
        //    {
        //        public string SetAside;
        //        public decimal SetAsideValue
        //        {
        //            get { return decimal.Parse(SetAside) / 100; }
        //        }

        //        public string AGMI;
        //        public decimal AGMIValue
        //        {
        //            get
        //            {
        //                return decimal.Parse(AGMI) / 100;
        //            }
        //        }
        //        public string AGMIFamilyCountString
        //        {
        //            get { return string.Format("AGMI{0}FamilyCount", AGMI) + "{0}"; }
        //        }
        //    }

            //private static Dictionary<string, MinimunSetAsideType> minimunSetAsideTypes = null;
            //public static Dictionary<string, MinimunSetAsideType> MinimunSetAsideTypes
            //{
            //    get { return minimunSetAsideTypes; }
            //}

        //    public static Dictionary<string, MinimunSetAsideType> getMinimunSetAsideTypeCode(TCRuleEngineDataSet oTCDataSet)
        //    {
        //        if (minimunSetAsideTypes == null)
        //            minimunSetAsideTypes = (from r in oTCDataSet.tcMinimumSetAsideType
        //                                    where r.IsActive == true
        //                                    select r
        //                                    ).ToDictionary(
        //                                        rr => rr.MinimumSetAsideTypeCode,
        //                                        rr => new MinimunSetAsideType
        //                                        {
        //                                            AGMI = rr.MinimumSetAsideType.Remove(0, rr.MinimumSetAsideType.Length - 2),
        //                                            SetAside = rr.MinimumSetAsideType.Substring(0, 2)
        //                                        }
        //                                    );

        //        return minimunSetAsideTypes;
        //    }
        //}

        public enum EMinimumSetAsideTypeCode
        {
            A = 40,
            B = 50,
            C = 60,
            D = 60,
        }

        public enum ERules
        {
            TIC,
            MovIn,
            Building,
            Alarm,
            AGMI
        }

        public static class MinimumIncomeFormulaCode
        {
            public const string G = "G";
            public const string N = "N";
            public const string R = "R";
        }

    }
}
