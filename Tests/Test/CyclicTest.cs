using FakerLib;
using FakerLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Classes;
using Xunit;

namespace Tests.Test
{
    public class CyclicTest
    {
        private Faker _faker = new Faker();

        [Fact]
        public void CyclicDependencies()
        {
            Assert.Throws<CyclicException>(() => _faker.Create<CyclicFirst>());
        }
    }
}
