using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class CFTK
    {
        public int FtkId { get; set; }
        public int FirstKindId { get; set; }
        public string FirstKindName { get; set; }
        public int SecondKindId { get; set; }
        public string SecondKindName { get; set; }
        public int ThirdKindId { get; set; }
        public string ThirdKindName { get; set; }
        public int ThirdKindSaleId { get; set; }
        public string ThirdKindIsRetail { get; set; }

        public List<CFTK> children { get; set; }

        public List<CFTK> Chlidren { get; set; }
    } 
}
