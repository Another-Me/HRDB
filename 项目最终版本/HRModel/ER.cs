    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class ER
    {
        public int ResId { get; set; }
        public string HumanName { get; set; }
        public string EngageType { get; set; }
        public string HumanAddress { get; set; }
        public string HumanPostcode { get; set; }
        public int HumanMajorKindId { get; set; }
        public string HumanMajorKindName { get; set; }
        public int HumanMajorId { get; set; }
        public string HunmaMajorName { get; set; }
        public string HumanTelephone { get; set; }
        public string HumanHomephone { get; set; }
        public string HumanMobilephone { get; set; }
        public string HumanEmail { get; set; }
        public string HumanHobby { get; set; }
        public string HumanSpeciality { get; set; }
        public string HumanSex { get; set; }
        public string HumanReligion { get; set; }
        public string HumanParty { get; set; }
        public string HumanNationality { get; set; }
        public string HumanRace { get; set; }
        public DateTime HumanBirthday { get; set; }
        public string Email { get; set; }
        public int HumanAge { get; set; }
        public string HumanEducatedDegree { get; set; }
        public int HumanEducatedYears { get; set; }
        public string HumanEducatedMajor { get; set; }
        public string HumanCollege { get; set; }
        public string HumanIdcard { get; set; }
        public string HumanBirthplace { get; set; }
        public string DemandSalaryStandard { get; set; }
        public string HumanHistoryRecords { get; set; }
        public string Remark { get; set; }
        public string Recomandation { get; set; }
        public string HumanPicture { get; set; }
        public string AttachmentName { get; set; }
        public int CheckStatus { get; set; }
        public string Register { get; set; }
        public DateTime RegistTime { get; set; }
        public string Checker { get; set; }
        public DateTime CheckTime { get; set; }
        public int InterviewStatus { get; set; }
        public string TotalPoints { get; set; }
        public int TestAmount { get; set; }
        public int TestChecker { get; set; }
        public DateTime TestCheckTime { get; set; }
        public int PassRegister { get; set; }
        public DateTime PassRegistTime { get; set; }
        public int PassChecker { get; set; }
        public DateTime PassCheckTime { get; set; }
        public int PassCheckStatus { get; set; }
        public string PassCheckComment { get; set; }
        public string PassPassComment { get; set; }
        public int MajorKindId { get; set; }//职位分类编号
        public string MajorKindName { get; set; }//职位分类名称
        public int MajorId { get; set; }//职位编号
        public string MajorName { get; set; }//职位名称
        public int MreId { get; set; } //对应招聘公司
    }
}
