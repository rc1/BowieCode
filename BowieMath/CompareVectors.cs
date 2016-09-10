using UnityEngine;

namespace BowieCode {

    public partial class BowieMath {

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
    }
}