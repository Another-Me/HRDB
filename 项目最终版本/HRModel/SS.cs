using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class SS
    {
        public int SsdId { get; set; }
        public string StandardId { get; set; }
        public string StandardName { get; set; }
        public string Designer { get; set; }
        public string Register { get; set; }
        public string Checker { get; set; }
        public string Changer { get; set; }
        public DateTime RegistTime { get; set; }
        public DateTime CheckTime { get; set; }
        public DateTime ChangeTime { get; set; }
        public int SalarySum { get; set; }
        public string CheckStatus { get; set; }
        public string ChangeStatus { get; set; }
        public string CheckComment { get; set; }
        public string Remark { get; set; }
    }
}
