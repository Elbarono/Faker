using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using FakerLib.Generator;
using FakerLib.Interface;

namespace FakerLib
{
    public class Generators
    {
        private Dictionary<Type, IGenerator> GeneratorDictionary = new Dictionary<Type, IGenerator>();
        public bool CheckGenerator(Type type)
        {
            return GeneratorDictionary.ContainsKey(type);
        }
        public object Generate(Type type)
        {
            if (CheckGenerator(type))
            {
                return GeneratorDictionary[type].Generate();
            }
            return null;
        }
        public Generators()
        {
            GeneratorDictionary.Add(typeof(int), new IntGenerator());
            GeneratorDictionary.Add(typeof(double), new DoubleGenerator());
            GeneratorDictionary.Add(typeof(DateTime), new DateGenerator());
            GeneratorDictionary.Add(typeof(bool), new BoolGenerator());
            AddPluginGenerators();
        }

        public void AddGenerator(Type type, IGenerator newGenerator)
        {
            GeneratorDictionary.Add(type, newGenerator);
        }

        private void AddPluginGenerators()
        {
            string path = Directory.GetCurrentDirectory();
            string[] dlls = Directory.GetFiles(path, "GeneratorPlugins.dll");
            foreach (string dll in dlls)
            {
                Assembly asm = Assembly.LoadFrom(dll);
                foreach (var type in asm.GetExportedTypes())
                {
                    if (type.IsClass && typeof(IGenerator).IsAssignableFrom(type))
                    {
                        IGenerator generator = (IGenerator)Activator.CreateInstance(type);
                        GeneratorDictionary.Add(generator.GetGeneratedType(), generator);
                    }
                }
            }
        }
    }
}
