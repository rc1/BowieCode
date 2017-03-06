using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BowieCode {

	public class BowieMath {

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
			
		/// <summary>
		/// Compares if Vector are close to equal. See: http://answers.unity3d.com/questions/131624/vector3-comparison.html
		/// </summary>
		/// <param name="a">a</param>
		/// <param name="b">b</param>
		/// <param name="angleError">Allowed difference in angle</param>
		/// <returns>If they are close to equal</returns>
		public static bool CompareVectors ( Vector3 a, Vector3 b, float angleError = 0.1f ) {

			//if they aren't the same length, don't bother checking the rest.
			if ( !Mathf.Approximately( a.magnitude, b.magnitude ) ) {
				return false;
			}

			float cosAngleError = Mathf.Cos( angleError * Mathf.Deg2Rad );
			//A value between -1 and 1 corresponding to the angle.
			float cosAngle = Vector3.Dot( a.normalized, b.normalized );
			//The dot product of normalized Vectors is equal to the cosine of the angle between them.
			//So the closer they are, the closer the value will be to 1.  Opposite Vectors will be -1
			//and orthogonal Vectors will be 0.

			if ( cosAngle >= cosAngleError ) {
				//If angle is greater, that means that the angle between the two vectors is less than the error allowed.
				return true;
			}
			else {
				return false;
			}
		}

		/// <summary>
		/// Change an input from one range to another.
		/// </summary>
		/// <param name="input">The value to change</param>
		/// <param name="inputMin">The value's min in range</param>
		/// <param name="inputMax">The value's max in range</param>
		/// <param name="outputMin">The output's min in range</param>
		/// <param name="outputMax">The output's max in range</param>
		/// <param name="clamp">Constraigns the output to the max range</param>
		/// <returns></returns>
		static public float MapIntervalF ( float input, float inputMin, float inputMax, float outputMin, float outputMax, bool clamp = false ) {
			input = ( input - inputMin ) / ( inputMax - inputMin );
			float output = input * ( outputMax - outputMin ) + outputMin;
			if ( clamp ) {
				if ( outputMax < outputMin ) {
					if ( output < outputMax ) {
						output = outputMax;
					}
					else if ( output > outputMin ) {
						output = outputMin;
					}
				}
				else {
					if ( output > outputMax ) {
						output = outputMax;
					}
					else if ( output < outputMin ) {
						output = outputMin;
					}
				}
			}
			return output;
		}

		/// <summary>
		/// Helper to make a cos wave with an amplitude and frequency
		/// </summary>
		/// <param name="time">Use Time.time</param>
		/// <param name="amplitude">The range of the output</param>
		/// <param name="frequency">The number of cycles per second</param>
		/// <returns></returns>
		static public float CosF ( float time, float amplitude, float frequency ) {
			return amplitude * Mathf.Cos( 2.0f * Mathf.PI * frequency * time );
		}

		/// <summary>
		/// Helper to make a sine wave with an amplitude and frequency
		/// </summary>
		/// <param name="time">Use Time.time</param>
		/// <param name="amplitude">The range of the output</param>
		/// <param name="frequency">The number of cycles per second</param>
		/// <returns></returns>
		static public float SineF ( float time, float amplitude, float frequency ) {
			return amplitude * Mathf.Sin( 2.0f * Mathf.PI * frequency * time );
		}

		/// <summary>
		/// Helper to make a tan wave with an amplitude and frequency
		/// </summary>
		/// <param name="time">Use Time.time</param>
		/// <param name="amplitude">The range of the output</param>
		/// <param name="frequency">The number of cycles per second</param>
		/// <returns></returns>
		static public float TanF ( float time, float amplitude, float frequency ) {
			return amplitude * Mathf.Tan( 2.0f * Mathf.PI * frequency * time );
		}

	}

}