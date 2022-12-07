using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Classes
{
    public class CyclicSecond
    {
        public int ID { get; set; }
        public CyclicFirst First { get; set; }
    }
}
