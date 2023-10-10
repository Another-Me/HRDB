using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{

    /// <summary>
    /// 职位发表登记表
    /// </summary>
    public class EMR
    {
        public int MreId { get; set; }
        public int FirstKindId { get; set; }
        public string FirstKindName { get; set; }
        public int SecondKindId { get; set; }
        public string SecondKindName { get; set; }
        public int ThirdKindId { get; set; }
        public string ThirdKindName { get; set; }
        public int MajorId { get; set; }
        public string MajorName { get; set; }
        public string HumanAmount { get; set; }
        public string EngageType { get; set; }
        public DateTime Deadline { get; set; }
        public string Register { get; set; }
        public string Changer { get; set; }
        public DateTime RegistTime { get; set; }
        public DateTime ChangeTime { get; set; }
        public string MajorDescribe { get; set; }
        public string EngageRequired { get; set; }
        public int MajorKindId { get; set; }//职位分类编号
        public string MajorKindName { get; set; }
        public string Format
        {
            get
            {
                return Deadline.ToString("yyyy-MM-dd");
            }
        }
    }
}
