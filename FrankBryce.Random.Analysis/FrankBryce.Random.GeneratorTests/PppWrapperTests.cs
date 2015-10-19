using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrankBryce.Random.Generator.Tests
{
    [TestClass()]
    public class PppWrapperTests
    {
        private PppWrapper GetUnitUnderTest()
        {
            return new PppWrapper();
        }

        [TestMethod()]
        public void GetRandomCharArrayTest()
        {
            var uut = GetUnitUnderTest();
            Assert.IsNotNull(uut);
        }

        [TestMethod()]
        public void GetRandomCharArray_ANonNullObject()
        {
            var uut = GetUnitUnderTest();
            var charArray = uut.GetRandomCharArray();
            Assert.IsNotNull(charArray);
        }

        [TestMethod()]
        public void GetRandomCharArray_GeneratesHexCharArray()
        {
            var uut = GetUnitUnderTest();
            var charArray = uut.GetRandomCharArray();
            foreach(var item in charArray)
            {
                var isHexDigit =
                    item == '0' ||
                    item == '1' ||
                    item == '2' ||
                    item == '3' ||
                    item == '4' ||
                    item == '5' ||
                    item == '6' ||
                    item == '7' ||
                    item == '8' ||
                    item == '9' ||
                    item == 'a' ||
                    item == 'b' ||
                    item == 'c' ||
                    item == 'd' ||
                    item == 'e' ||
                    item == 'f';
                Assert.IsTrue(isHexDigit);
            }
        }
    }
}