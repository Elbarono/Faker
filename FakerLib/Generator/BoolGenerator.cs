using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerLib.Interface;

namespace FakerLib.Generator
{
    public class BoolGenerator : IGenerator
    {
        public object Generate()
        {
            return false;
        }

        public Type GetGeneratedType()
        {
            return typeof(bool);
        }
    }
}
