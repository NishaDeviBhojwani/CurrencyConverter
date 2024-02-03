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
        public void GetDigitsIntoNumbersTest()
        {
            var result = _converter.GetDigitsIntoNumbers("0,69");

            Assert.AreEqual(result, "sixty nine cents");
        }
    }
}