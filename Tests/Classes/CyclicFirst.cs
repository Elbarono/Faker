using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Classes
{
    public class CyclicFirst
    {
        public int ID { get; set; }
        public CyclicSecond Second { get; set; }
    }
}
