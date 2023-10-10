using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    /// <summary>
    /// 分页数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FenYe<T>
    {
        public int Rows { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string condition { get; set; }

        public string Where { get; set; }
        public IEnumerable<T> List { get; set; }
    }
}
