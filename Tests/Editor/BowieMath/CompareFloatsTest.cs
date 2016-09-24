namespace BowieCode {
	using NUnit.Framework;
	using System;
	using UnityEngine;

	[TestFixture]
	public class BowieMathCompareFloatsTest {

		[Test]
		public void OneAndThreeAreMoreThanOneApart () {
			Assert.False( BowieMath.CompareFloats( 1, 3, 1 ) );
		}

		[Test]
		public void OneAndThreeAreLessThanFourApart () {
			Assert.True( BowieMath.CompareFloats( 1, 3, 4 ) );
		}

	} 
}
