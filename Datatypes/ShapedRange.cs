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

		public ShapedRange () {}

		public ShapedRange ( float constant ) {
			this.constant = constant;
		}

		public ShapedRange ( Vector2 linear ) {
			this.linear = linear;
		}

		public ShapedRange ( AnimationCurve curve ) {
			this.curve = curve;
		}


		public enum Shape {
			Constant,
			Linear,
			Curve
		}

		public Shape shape = Shape.Constant;

		public float constant;
		public Vector2 linear;
		public AnimationCurve curve;

		public float Evaluate () {
			return Evaluate( 0.0f );
		}

		public float Evaluate( float scaler ) {
			if ( shape == Shape.Constant ) {
				return constant;
			} else if ( shape == Shape.Linear ) {
				return Mathf.InverseLerp( linear.x, linear.y, scaler );
			} 
			return curve.Evaluate( scaler );
		}

	}

}
