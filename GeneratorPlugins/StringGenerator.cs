using FakerLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorPlugins
{
    public class StringGenerator : IGenerator
    {
        public object Generate()
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            char[] salt = new char[32];
            Random random = new Random();
            int symbolsLength = chars.Length;
            for (int i = 0; i < 32; i++)
            {
                salt[i] = chars[random.Next(0, symbolsLength)];
            }
            return new string(salt);
        }

        public Type GetGeneratedType()
        {
            return typeof(string);
        }
    }
}
