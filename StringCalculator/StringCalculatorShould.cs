using NUnit.Framework;

namespace StringCalculator
{
    public class StringCalculatorShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReturnCeroWhenEmptyInput()
        {
            Assert.AreEqual(0, new Calculator().Add(""));
        }

        [Test]
        public void AddSingleNumber()
        {
            Assert.AreEqual(1, new Calculator().Add("1"));
        }

        [TestCase("1,2", 3)]
        [TestCase("2,2", 4)]
        [TestCase("5,5", 10)]
        public void AddNumbersSeparatedWithComma(string input, int result)
        {
            Assert.AreEqual(result, new Calculator().Add(input));
        }
    }
}