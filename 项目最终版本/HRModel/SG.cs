using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class SG
    {
        public int SgrId { get; set; }
        public int SalaryGrantId { get; set; }
        public int SalaryStandardId { get; set; }
        public int FirstKindId { get; set; }
        public string FirstKindName { get; set; }
        public int SecondKindId { get; set; }
        public string SecondKindName { get; set; }
        public int ThirdKindId { get; set; }
        public string ThirdKindName { get; set; }
        public int HumanAmount { get; set; }
        public int SalaryStandardSum { get; set; }
        public int SalaryPaidSum { get; set; }
        public string Register { get; set; }
        public DateTime RegistTime { get; set; }
        public string Checker { get; set; }
        public DateTime CheckTime { get; set; }
        public string CheckStatus { get; set; }

        public int we { get; set; }
        public int jine { get; set; }
    }
}
