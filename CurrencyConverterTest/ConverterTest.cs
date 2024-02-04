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
        public void GetDigitsIntoNumbers_1Dollar10CentsTest()
        {
            var result = _converter.GetNumIntoWords("1,1");

            Assert.AreEqual(result, "One dollar ten cents");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_25Dollar10CentsTest()
        {
            var result = _converter.GetNumIntoWords("25,1");

            Assert.AreEqual(result, "twenty five dollars ten cents");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_139DollarTest()
        {
            var result = _converter.GetNumIntoWords("999 000 999,99");

            Assert.AreEqual(result, "One hundred thirty nine dollar 10 cents");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_1390DollarTest()
        {
            var result = _converter.GetNumIntoWords("999 000 999,99");

            Assert.AreEqual(result, "One hundred thirty nine dollar 10 cents");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_13902DollarTest()
        {
            var result = _converter.GetNumIntoWords("999 000 999,99");

            Assert.AreEqual(result, "One hundred thirty nine dollar 10 cents");
        }

        [TestMethod]
        public void GetDigitsIntoNumbers_13901DollarTest()
        {
            var result = _converter.GetNumIntoWords("999 000 999,99");

            Assert.AreEqual(result, "One hundred thirty nine dollar 10 cents");
        }

    }
}