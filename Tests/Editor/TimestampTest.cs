namespace BowieCode {
    using NUnit.Framework;

    [TestFixture]
    public class TimeTest {

        [Test]
        public void Now () {
            double result = BowieTime.Now();
            Assert.GreaterOrEqual( result, 1473515478745d );
        }

        [Test]
        public void NowStr () {
            string result = BowieTime.NowStr();
            Assert.AreEqual( result.Length, 13 );
        }

    }
}
