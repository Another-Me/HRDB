using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    /// <summary>
    ///  CMK:职位分类设置表
    /// </summary>
    public class CMK
    {
        public int MfkId { get; set; }  //主键
        public int MajorKindId { get; set; }    //职位分类编号
        public string MajorKindName { get; set; }  //职分类位名称

        public List<CMK> children { get; set; }
    }
}
