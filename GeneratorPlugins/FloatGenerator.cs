using FakerLib.Interface;

namespace GeneratorPlugins
{
    public class FloatGenerator : IGenerator
    {
        public object Generate()
        {
            return (float)new Random().NextDouble();
        }

        public Type GetGeneratedType()
        {
            return typeof(float);
        }
    }
}