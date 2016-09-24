namespace BowieCode {
    using NUnit.Framework;
	using System;
	using UnityEngine;

    [TestFixture]
    public class BowieTimeTest {

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

		[Test]
		public void PercentOfDay() {
			DateTime time = new DateTime( 2008, 3, 1, 12, 0, 0 );
			Assert.True( BowieMath.CompareFloats( 0.5f, BowieTime.PercentOfDay( time ), 0.0001f ) );
		}

		[Test]
		public void PercentOfYear() {
			DateTime time = new DateTime( 2009, 7, 1, 0, 0, 0 );
			Assert.True( BowieMath.CompareFloats( 0.5f, BowieTime.PercentOfYear( time ), 0.01f ) );
		}

    }
}
