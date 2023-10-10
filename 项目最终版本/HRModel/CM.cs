using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    /// <summary>
    /// 职位设置表
    /// </summary>
    public class CM
    {
        public int MakId { get; set; }  //主键  自动增长列
        public int MajorKindId { get; set; }    //职位分类编号
        public string MajorKindName { get; set; }   //职位分类名称
        public int MajorId { get; set; }    //职位编号
        public string MajorName { get; set; }   //职位名称
        public int? TestAmount { get; set; }  //题套数量

        public List<CM> Chlidren { get; set; }
        public List<CM> Children { get; set; }

    }
}
