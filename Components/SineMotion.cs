using UnityEngine;
using System.Collections.Generic;

namespace BowieCode {

    /// <summary>
    /// Apply sine based motions to the transform component
    /// </summary>
    public class SineMotion : MonoBehaviour {

        [System.Serializable]
        public class SineMotionParam {
            public bool isEnabled = false;
            public float amplitude = 1.0f;
            public float cyclesPerSecond = 1.0f;
            public float offset = 0.0f;
            public float GetValue ( float time ) {
                return BowieMath.SineF(  time + offset, amplitude, cyclesPerSecond );
            }
        }

        [Header("Position")]
        public SineMotionParam xPosition;
        public SineMotionParam yPosition;
        public SineMotionParam zPosition;

        [Header("Rotation")]
        public SineMotionParam xRotation;
        public SineMotionParam yRotation;
        public SineMotionParam zRotation;

        [Header("Scale")]
        public SineMotionParam xScale;
        public SineMotionParam yScale;
        public SineMotionParam zScale;

        [Header("Options")]
        public float timeScale = 1.0f;
        
	    void Start () {}
	
	    void Update () {

            // Position
            // --------

            Vector3 currentPosition = transform.localPosition;

            if ( xPosition.isEnabled ) {
                currentPosition.x = xPosition.GetValue( Time.time * timeScale );
            }
            if ( yPosition.isEnabled ) {
                currentPosition.y = yPosition.GetValue( Time.time * timeScale );
            }
            if ( zPosition.isEnabled ) {
                currentPosition.z = zPosition.GetValue( Time.time * timeScale );
            }

            transform.localPosition = currentPosition;

            // Rotation
            // --------

            Vector3 currentRotation = transform.rotation.eulerAngles;

            if ( xRotation.isEnabled ) {
                currentRotation.x = xRotation.GetValue( Time.time * timeScale );
            }
            if ( yRotation.isEnabled ) {
                currentRotation.y = yRotation.GetValue( Time.time * timeScale );
            }
            if ( zRotation.isEnabled ) {
                currentRotation.z = zRotation.GetValue( Time.time * timeScale );
            }

            transform.localRotation = Quaternion.Euler( currentRotation );

            // Scale
            // -----

            Vector3 currentScale = transform.localScale;

            if ( xScale.isEnabled ) {
                currentScale.x = xScale.GetValue( Time.time * timeScale );
            }
            if ( yScale.isEnabled ) {
                currentScale.y = yScale.GetValue( Time.time * timeScale );
            }
            if ( zScale.isEnabled ) {
                currentScale.z = zScale.GetValue( Time.time * timeScale );
            }

            transform.localScale = currentScale;
	
	    }
    }

}
