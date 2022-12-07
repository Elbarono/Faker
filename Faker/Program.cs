using FakerLib.Interface;
using System;
using System.Text.Json;

namespace Faker
{
    class LongGenerator : IGenerator
    {
        public object Generate()
        {
            return new Random().NextInt64();
        }

        public Type GetGeneratedType()
        {
            return typeof(long);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IFaker faker = new FakerLib.Faker();
            ((FakerLib.Faker)faker).AddGenerator(typeof(long), new LongGenerator());
            var temp = faker.Create<Company>();
            var json = JsonSerializer.Serialize(temp, new JsonSerializerOptions() { WriteIndented = true });
            Console.WriteLine(json);
            temp = faker.Create<Company>();
            json = JsonSerializer.Serialize(temp, new JsonSerializerOptions() { WriteIndented = true });
            Console.WriteLine(json);
        }
    }
}
