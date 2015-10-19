using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrankBryce.Random.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrankBryce.Random.Generator.Tests
{
    [TestClass()]
    public class RandomHexEnumerableTests
    {
        private RandomHexEnumerable GetUnitUnderTest()
        {
            return new RandomHexEnumerable(new PppWrapper());
        }

        [TestMethod()]
        public void GetEnumeratorTest_UnitUnderTestIsNotNull()
        {
            var uut = GetUnitUnderTest();
            Assert.IsNotNull(uut);
        }

        [TestMethod()]
        public void GetEnumeratorTest_Gets1000Characters()
        {
            var uut = GetUnitUnderTest();
            var chars = uut.Take(1000);
            Assert.AreEqual(1000, chars.ToArray().Length);
        }

    }
}