using CurrencyConverter;

namespace CurrencyConverterTest
{
    [TestClass]
    public class ConverterTest
    {
        private readonly Converter _converter;
        public ConverterTest() {
            _converter = new Converter();
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_10CentsTest()
        {
            var result = _converter.GetNumIntoWords("0,1");

            Assert.AreEqual(result, "ten cents");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_01CentsTest()
        {
            var result = _converter.GetNumIntoWords("0,01");

            Assert.AreEqual(result, "one cents");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_70CentsTest()
        {
            var result = _converter.GetNumIntoWords("0,70");

            Assert.AreEqual(result, "seventy cents");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_99CentsTest()
        {
            var result = _converter.GetNumIntoWords("0,99");

            Assert.AreEqual(result, "ninty nine cents");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_1Dollar10CentsTest()
        {
            var result = _converter.GetNumIntoWords("1,1");

            Assert.AreEqual(result, "one dollars and ten cents");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_25Dollar11CentsTest()
        {
            var result = _converter.GetNumIntoWords("25,11");

            Assert.AreEqual(result, "twenty five dollars and eleven cents");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_11Dollar25CentsTest()
        {
            var result = _converter.GetNumIntoWords("11,25");

            Assert.AreEqual(result, "eleven dollars and twenty five cents");
        }
        [TestMethod]
        public void GetDigitsIntoNumbers_12123DollarTest()
        {
            var result = _converter.GetNumIntoWords("12 123");

            Assert.AreEqual(result, "twelve thousand one hundred twenty three dollars ");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_999000999Dollar99CentsTest()
        {
            var result = _converter.GetNumIntoWords("999 000 999,99");

            Assert.AreEqual(result, "nine hundred ninty nine million nine hundred ninty nine dollars and ninty nine cents");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_999999999Dollar01Test()
        {
            var result = _converter.GetNumIntoWords("999 999 999,99");

            Assert.AreEqual(result, "nine hundred ninty nine million nine hundred ninty nine thousand nine hundred ninty nine dollars and ninty nine cents");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_45100Dollars10CentTest()
        {
            var result = _converter.GetNumIntoWords("45 100,09");

            Assert.AreEqual(result, "forty five thousand one hundred   dollars and nine cents");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_0Dollars01CentTest()
        {
            var result = _converter.GetNumIntoWords("0,01");

            Assert.AreEqual(result, "one cents");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_0DollarsTest()
        {
            var result = _converter.GetNumIntoWords("0");

            Assert.AreEqual(result, "zero dollars");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_1DollarsTest()
        {
            var result = _converter.GetNumIntoWords("1");

            Assert.AreEqual(result, "one dollars ");
        }
    }
}