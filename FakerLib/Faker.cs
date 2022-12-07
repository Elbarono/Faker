using FakerLib.Interface;
using FakerLib.Exceptions;
using System.Collections;
using System.Reflection;

namespace FakerLib
{
    public class Faker : IFaker
    {
        private Generators Generators;
        private List<Type> UserTypes;

        public Faker()
        {
            Generators = new Generators();
        }

        public void AddGenerator(Type typeGenerator, IGenerator generator)
        {
            Generators.AddGenerator(typeGenerator, generator);
        }

        public T Create<T>()
        {
            UserTypes = new List<Type>();
            return (T)CreateDTO(typeof(T));
        }

        private object CreateDTO(Type type)
        {
            if (Generators.CheckGenerator(type))
            {
                return Generators.Generate(type)!;
            }

            if (type.IsGenericType)
            {
                var List = (IList)Activator.CreateInstance(type);
                var ListType = type.GetGenericArguments()[0];
                List.Add(CreateDTO(ListType));
                List.Add(CreateDTO(ListType));
                return List;
            }

            if (!UserTypes.Contains(type))
            {
                UserTypes.Add(type);
                var ResultObj = CreateObject(type);
                Initialize(ResultObj);
                UserTypes.Remove(type);
                return ResultObj;
            }
            throw new CyclicException();
        }

        private void Initialize(object obj)
        {
            var fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            foreach (var field in fields)
            {
                var fd = CreateDTO(field.FieldType);
                field.SetValue(obj, fd);
            }

            var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    var pr = CreateDTO(property.PropertyType);
                    property.SetValue(obj, pr);
                }
            }
        }

        private ConstructorInfo GetConstructor(Type type)
        {
            var constructors = type.GetConstructors();
            var constructor = constructors.OrderBy(c => c.GetParameters().Count()).FirstOrDefault();
            return constructor;
        }

        private object CreateObject(Type type)
        {
            var constructor = GetConstructor(type);
            var constructorParameters = constructor.GetParameters();
            var paramsList = new List<object>();
            foreach (var parameter in constructorParameters)
            {
                paramsList.Add(CreateDTO(parameter.ParameterType));
            }
            return constructor.Invoke(paramsList.ToArray());
        }
    }
}