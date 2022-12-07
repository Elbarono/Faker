using Xunit;
using FakerLib;
using Tests.Classes;

namespace Tests.Test
{
    public class SimpleTest
    {
        private Faker _faker = new Faker();
        [Fact]
        public void CreateStringClass()
        {
            var temp = _faker.Create<StringField>();
            Assert.NotNull(temp);
        }

        [Fact]
        public void CreateClassWithClass()
        {
            var temp = _faker.Create<ClassField>();
            Assert.NotNull(temp);
        }
    }
}