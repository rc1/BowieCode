using UnityEngine;

namespace BowieCode {

    /// <summary>
    /// Hides the mouse after a set number of seconds
    /// </summary>
    public class MouseHider : MonoBehaviour {

        private Vector3 _lastMousePosition;
        private float _lastMouseMoveTime = 0;
        public float hideMouseAfter = 120.0f;

        void Start () {
            if ( !Input.mousePresent ) {
                Cursor.visible = false;
            }
        }

        // Update is called once per frame
        void Update () {

            if ( !BowieMath.CompareVectors( _lastMousePosition, Input.mousePosition ) ) {
                _lastMouseMoveTime = Time.fixedTime;
            }

            _lastMousePosition = Input.mousePosition;

            Cursor.visible = ( Time.fixedTime - _lastMouseMoveTime < hideMouseAfter );

        }
    }

}
