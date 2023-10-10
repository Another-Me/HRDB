using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class CFSK
    {
        public int FskId { get; set; }
        public int FirstKindId { get; set; }
        public string FirstKindName { get; set; }
        public int SecondKindId { get; set; }
        public string SecondKindName { get; set; }
        public int SecondSalaryId { get; set; }
        public int SecondSaleId { get; set; }

        public List<CFSK> childern { get; set; }
    }
}
