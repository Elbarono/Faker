using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerLib.Interface;

namespace FakerLib.Generator
{
    public class DoubleGenerator : IGenerator
    {
        public object Generate()
        {
            return new Random().NextDouble() * 10000;
        }

        public Type GetGeneratedType()
        {
            return typeof(double);
        }
    }
}
