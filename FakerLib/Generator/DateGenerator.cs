using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerLib.Interface;

namespace FakerLib.Generator
{
    public class DateGenerator : IGenerator
    {
        public object Generate()
        {
            return DateTime.Now;
        }

        public Type GetGeneratedType()
        {
            return typeof(DateTime);
        }
    }
}
