using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    /// <summary>
    /// 面试表
    /// </summary>
    public class EI
    {
        public int EinId { get; set; }
        public string HumanName { get; set; }

        public int InterviewAmount { get; set; }
        public int HumanMajorKindId { get; set; }
        public string HumanMajorKindName { get; set; }
        public int HumanMajorId { get; set; }
        public string HunmaMajorName { get; set; }

        public string ImageDegree { get; set; }
        public string NativeLanguageDegree { get; set; }
        public string ForeignLanguageDegree { get; set; }
        public string ResponseSpeedDegree { get; set; }
        public string EQDegree { get; set; }
        public string IQDegree { get; set; }
        public string MultiQualityDegree { get; set; }
        public string Register { get; set; }
        public string Checker { get; set; }
        public DateTime RegisteTime { get; set; }
        public DateTime CheckTime { get; set; }
        public int ResumeId { get; set; }

        public string Result { get; set; }
        public string InterviewComment { get; set; }
        public string CheckComment { get; set; }
        public int InterviewStatus { get; set; }
        public int CheckStatus { get; set; }

        public int MajorKindId { get; set; }//职位分类编号
        public string MajorKindName { get; set; }//职位分类名称
        public int MajorId { get; set; }//职位编号
        public string MajorName { get; set; }//职位名称
    }
}
