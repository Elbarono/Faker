using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FakerLib;
using Tests.Classes;

namespace Tests.Test
{
    public class ListTest
    {
        private Faker _faker = new Faker();
        [Fact]
        public void CreateIntList()
        {
            var temp = _faker.Create<IntList>();
            Assert.NotNull(temp);
        }

        [Fact]
        public void CreateClassWithStringClassList()
        {
            var temp = _faker.Create<ListStringField>();
            Assert.NotNull(temp);
        }
    }
}
