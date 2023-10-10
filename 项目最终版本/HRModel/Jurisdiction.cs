using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class Jurisdiction
    {
        public int JuriID { get; set; }
        public string JurName { get; set; }
        public int GroupID { get; set; }
        public string JurAddress { get; set; }
        public int pidd { get; set; }

        public List<Jurisdiction> children { get; set;}
    }
}
