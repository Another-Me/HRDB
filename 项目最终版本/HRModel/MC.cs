using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class MCi
    {
        public int MchId { get; set; }
        public int FirstKindId { get; set; }
        public string FirstKindName { get; set; }
        public int SecondKindId { get; set; }
        public string SecondKindName { get; set; }
        public int ThirdKindId { get; set; }
        public string ThirdKindName { get; set; }
        public int MajorKindId { get; set; }
        public string MajorKindName { get; set; }
        public int MajorId { get; set; }
        public string MajorName { get; set; }
        public int NewFirstKindId { get; set; }
        public string NewFirstKindName { get; set; }
        public int NewSecondKindId { get; set; }
        public string NewSecondKindName { get; set; }
        public int NewThirdKindId { get; set; }
        public string NewThirdkindName { get; set; }
        public int NewMajorKindId { get; set; }
        public string NewMajorKindName { get; set; }
        public int NewMajorId { get; set; }
        public string NewMajorName { get; set; }
        public string HumanId { get; set; }
        public string HumanName { get; set; }
        public int SalaryStandardId { get; set; }
        public string SalaryStandardName { get; set; }
        public string SalarySum { get; set; }
        public int NewSalaryStandardId { get; set; }
        public string NewSalaryStandardName { get; set; }
        public string NewSalarySum { get; set; }
        public string ChangeReason { get; set; }
        public string CheckReason { get; set; }
        public string CheckStatus { get; set; }
        public string Register { get; set; }
        public string Checker { get; set; }
        public DateTime RegistTime { get; set; }
        public DateTime CheckTime { get; set; }
        public string RegistTime1
        {
            get { return RegistTime.ToString("yyyy-MM-dd"); }
            
        }
        public string CheckTime1 
        {
            get { return CheckTime.ToString("yyyy-MM-dd"); }
        }
        public List<MCi> Chilner { get; set; }
    }
}
