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

            Assert.AreEqual("ten cents", result);
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_01CentsTest()
        {
            var result = _converter.GetNumIntoWords("0,01");

            Assert.AreEqual("one cents", result);
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_70CentsTest()
        {
            var result = _converter.GetNumIntoWords("0,70");

            Assert.AreEqual("seventy cents", result);
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_99CentsTest()
        {
            var result = _converter.GetNumIntoWords("0,99");

            Assert.AreEqual("ninty nine cents", result);
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_1Dollar10CentsTest()
        {
            var result = _converter.GetNumIntoWords("1,1");

            Assert.AreEqual("one dollars and ten cents", result);
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_25Dollar11CentsTest()
        {
            var result = _converter.GetNumIntoWords("25,11");

            Assert.AreEqual("twenty five dollars and eleven cents", result);
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_11Dollar25CentsTest()
        {
            var result = _converter.GetNumIntoWords("11,25");

            Assert.AreEqual("eleven dollars and twenty five cents", result);
        }
        [TestMethod]
        public void GetDigitsIntoNumbers_12123DollarTest()
        {
            var result = _converter.GetNumIntoWords("12 123");

            Assert.AreEqual("twelve thousand one hundred twenty three dollars", result);
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_999000999Dollar99CentsTest()
        {
            var result = _converter.GetNumIntoWords("999 000 999,99");

            Assert.AreEqual("nine hundred ninty nine million nine hundred ninty nine dollars and ninty nine cents", result);
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_999999999Dollar01Test()
        {
            var result = _converter.GetNumIntoWords("999 999 999,99");

            Assert.AreEqual("nine hundred ninty nine million nine hundred ninty nine thousand nine hundred ninty nine dollars and ninty nine cents", result);
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_45100Dollars10CentTest()
        {
            var result = _converter.GetNumIntoWords("45 100,09");

            Assert.AreEqual("forty five thousand one hundred dollars and nine cents", result);
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_0Dollars01CentTest()
        {
            var result = _converter.GetNumIntoWords("0,01");

            Assert.AreEqual("one cents", result);
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_1DollarsTest()
        {
            var result = _converter.GetNumIntoWords("1");

            Assert.AreEqual("one dollars", result);
        }
    }
}