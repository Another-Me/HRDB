using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class HFD
    {
        public int HfdId { get; set; }

        public string HumanId { get; set; }

        public int FirstKindId { get; set; }
        public string FirstKindName { get; set; }
        public int SecondKindId { get; set; }
        public string SecondKindName { get; set; }
        public int ThirdKindId { get; set; }
        public string ThirdKindName { get; set; }
        public string HumanName { get; set; }
        public string HumanAddress { get; set; }
        public string HumanPostcode { get; set; }
        public string HumanProDesignation { get; set; }
        public int HumanMajorKindId { get; set; }
        public string HumanMajorKindName { get; set; }
        public int HumanMajorId { get; set; }
        public string HunmaMajorName { get; set; }
        public string HumanTelephone { get; set; }
        public string HumanMobilephone { get; set; }
        public string HumanBank { get; set; }
        public string HumanAccount { get; set; }
        public string HumanQQ { get; set; }
        public string HumanEmail { get; set; }
        public string HumanHobby { get; set; }
        public string HumanSpeciality { get; set; }
        public string HumanSex { get; set; }
        public string HumanReligion { get; set; }
        public string HumanParty { get; set; }
        public string HumanNationality { get; set; }
        public string HumanRace { get; set; }
        public DateTime HumanBirthday { get; set; }
        public string HumanBirthplace { get; set; }
        public int HumanAge { get; set; }
        public string HumanEducatedDegree { get; set; }
        public int HumanEducatedYears { get; set; }
        public string HumanEducatedMajor { get; set; }
        public int HumanSocietySecurityId { get; set; }
        public string HumanIdCard { get; set; }
        public string Remark { get; set; }
        public string SalaryStandardId { get; set; }
        public string SalaryStandardName { get; set; }
        public double SalarySum { get; set; }
        public double DemandSalaraySum { get; set; }
        public double PaidSalarySum { get; set; }
        public int MajorChangeAmount { get; set; }
        public int BonusAmount { get; set; }
        public int TrainingAmount { get; set; }
        public int FileChangAmount { get; set; }
        public string HumanHistroyRecords { get; set; }
        public string HumanFamilyMembership { get; set; }
        public string HumanPicture { get; set; }
        public string AttachmentName { get; set; }
        public int CheckStatus { get; set; }
        public int Register { get; set; }
        public int Checker { get; set; }
        public int Changer { get; set; }
        public DateTime RegistTime { get; set; }
        public DateTime CheckTime { get; set; }
        public DateTime ChangeTime { get; set; }
        public DateTime LastlyChangeTime { get; set; }
        public DateTime DeleteTime { get; set; }

        public DateTime RecoveryTime { get; set; }
        public int HumanFileStatus { get; set; }

    }
}
