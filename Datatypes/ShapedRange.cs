using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BowieCode {

	/// <summary>
	/// Shaped range can evaluate a constant value, a value between two numbers or a value from an Animation curve.
	/// These options can be selected in the editor. It's inspired by Unity's particle system.
	/// </summary>
	[System.Serializable]
	public class ShapedRange {
		
		/// <summary>
		/// Initializes a new instance of the <see cref="BowieCode.ShapedRange"/> class.
		/// </summary>
		public ShapedRange () {}

		/// <summary>
		/// Initializes a new instance of the <see cref="BowieCode.ShapedRange"/> class.
		/// </summary>
		/// <param name="constant">Constant float value</param>
		public ShapedRange ( float constant ) {
			this.constant = constant;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BowieCode.ShapedRange"/> class.
		/// </summary>
		/// <param name="linear">Linear.</param>
		public ShapedRange ( Vector2 linear ) {
			this.linear = linear;
		}

		public ShapedRange ( AnimationCurve curve ) {
			this.curve = curve;
		}

		public enum Shape {
			Constant,
			MinMax,
			Curve
		}

		public Shape shape = Shape.Constant;

		public float constant;
		public Vector2 linear;
		public AnimationCurve curve = AnimationCurve.Linear( 0.0f, 1.0f, 1.0f, 1.0f);

		/// <summary>
		/// Returns a random value from the range
		/// </summary>
		/// <returns>The random.</returns>
		public float GetRandom() {
			return Evaluate( Random.value );
		}
			
		/// <summary>
		/// Evaluate the specified scaler.
		/// </summary>
		/// <param name="scaler">Scaler.</param>
		public float Evaluate( float scaler ) {
			if ( shape == Shape.Constant ) {
				return constant;
			} else if ( shape == Shape.MinMax ) {
				return Mathf.Clamp( Mathf.InverseLerp( linear.x, linear.y, scaler ), linear.x, linear.y );
			} 
			return curve.Evaluate( scaler );
		}



	}

}
