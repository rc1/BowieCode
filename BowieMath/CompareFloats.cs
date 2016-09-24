using UnityEngine;

namespace BowieCode {
	public partial class BowieMath {
		/// <summary>
		/// Compare floats with a tolerance
		/// </summary>
		/// <returns><c>true</c>, if floats were equal withing the tolerance, <c>false</c> otherwise.</returns>
		/// <param name="a">Test a.</param>
		/// <param name="b">Test b.</param>
		/// <param name="tolerance">The range.</param>
		public static bool CompareFloats ( float a, float b, float tolerance = 0.0f ) {
			return ( Mathf.Abs( b - a ) < tolerance );
		}
	}
}