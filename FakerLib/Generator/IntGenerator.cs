using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerLib.Interface;

namespace FakerLib.Generator
{
    public class IntGenerator : IGenerator
    {
        public object Generate()
        {
            return new Random().Next();
        }

        public Type GetGeneratedType()
        {
            return typeof(int);
        }
    }
}
