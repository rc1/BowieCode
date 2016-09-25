using UnityEngine;

namespace BowieCode {

    /// <summary>
    /// Binds transform's z valie to near or far to a target camera's with a slight distance from. Components GameObject should be a child of the camera.
	/// </summary>
	[AddComponentMenu("BowieCode/Bind To Camera")]
	[ExecuteInEditMode]
    public class BindToCamera : MonoBehaviour {

        public enum BindMode {
            Near,
            Far
        };

        public BindMode bindMode;
        public Camera targetCamera;
        public float distanceFrom = 0.01f;

        private float _lastCameraNearPlane;
        private float _lastCameraFarPlane;
        private float _lastDistanceFrom;
        private BindMode _lastBindMode;

        void Start () {
            Move();
        }

        void Update () {
            if ( _lastCameraNearPlane != targetCamera.nearClipPlane
                || _lastCameraFarPlane != targetCamera.farClipPlane 
                || _lastDistanceFrom != distanceFrom
                || _lastBindMode != bindMode ) {
                Move();
            }
        }

        public void Move () {
            if ( bindMode == BindMode.Far ) {
                MoveToCameraFar();
            }
            else if ( bindMode == BindMode.Near ) {
                MoveToCameraNear();
            }
            _lastCameraNearPlane = targetCamera.nearClipPlane;
            _lastCameraFarPlane = targetCamera.farClipPlane;
			_lastDistanceFrom = distanceFrom;
            _lastBindMode = bindMode;
        }

        public void MoveToCameraNear () {
            float frontPosition = targetCamera.nearClipPlane + distanceFrom;
            Vector3 v = new Vector3( 0, 0, frontPosition );
            transform.localPosition = v;
        }

        public void MoveToCameraFar () {
            float backPosition = targetCamera.farClipPlane - distanceFrom;
            Vector3 v = new Vector3( 0, 0, backPosition );
            transform.localPosition = v;
        }
    }

}
