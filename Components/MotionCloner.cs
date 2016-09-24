using UnityEngine;

namespace BowieCode {

    /// <summary>
    /// Applies a master transforms position, rotation and scale to components transform. Provides options for using local or world space, and retaining offsets.
    /// </summary>
    public class MotionCloner : MonoBehaviour {

        public enum CoordinateSpace {
            World,
            Local
        };

        [System.Serializable]
        public class MotionClonerParam {
            public MotionClonerParam ( bool worldOffset, bool localOffset, CoordinateSpace masterSpace, CoordinateSpace localSpace ) {
                applyWorldOffset = worldOffset;
                applyLocalOffset = localOffset;
                masterSpace = CoordinateSpace.World;
                localSpace = CoordinateSpace.World;
            }
            public bool isEnabled = false;
            public bool applyWorldOffset = false;
            public bool applyLocalOffset = false;
            public CoordinateSpace masterCoordinateSpace = CoordinateSpace.World;
            public CoordinateSpace targetCoordinateSpace = CoordinateSpace.World;
        }
        
        public Transform masterTransform;
        public MotionClonerParam position = new MotionClonerParam( true, false, CoordinateSpace.World, CoordinateSpace.World );
        public MotionClonerParam rotation = new MotionClonerParam( true, false, CoordinateSpace.World, CoordinateSpace.World );
        public MotionClonerParam scale = new MotionClonerParam( true, false, CoordinateSpace.Local, CoordinateSpace.Local );
        
        private Vector3 _initialPositionLocal;
        private Vector3 _initialPositionWorld;
        private Quaternion _initialRotationLocal;
        private Quaternion _initialRotationWorld;
        private Vector3 _initialScaleLocal;
        private Vector3 _initialScaleWorld;

        void Start () {
            if ( masterTransform != null ) {
                _initialPositionWorld = masterTransform.position;
                _initialPositionLocal = masterTransform.localPosition;
                _initialRotationWorld = masterTransform.rotation;
                _initialRotationLocal = masterTransform.localRotation;
                _initialScaleWorld = masterTransform.lossyScale;
                _initialScaleLocal = masterTransform.localScale;
            }
        }

        void Update () {

            // Position
            // --------

            if ( position.isEnabled ) {
                // Get the master's position
                Vector3 newPosition = ( position.masterCoordinateSpace == CoordinateSpace.World ) ? masterTransform.position : masterTransform.localPosition;
                // Apply offset
                if ( position.applyLocalOffset ) {
                    newPosition = newPosition + _initialPositionLocal;
                }
                if ( position.applyWorldOffset ) {
                    newPosition = newPosition + _initialPositionWorld;
                }
                // Set
                if ( position.targetCoordinateSpace == CoordinateSpace.World ) {
                    transform.position = newPosition;
                }
                else {
                    transform.localPosition = newPosition;
                }
            }

            // Rotation
            // --------

            if ( rotation.isEnabled ) {
                // Get the master's rotataion
                Quaternion newRotation = ( rotation.masterCoordinateSpace == CoordinateSpace.World ) ? masterTransform.rotation : masterTransform.localRotation;
                // Apply offset
                if ( rotation.applyLocalOffset ) {
                    newRotation = newRotation * _initialRotationLocal;
                }
                if ( rotation.applyWorldOffset ) {
                    newRotation = newRotation * _initialRotationWorld; 
                }
                // Set
                if ( position.targetCoordinateSpace == CoordinateSpace.World ) {
                    transform.rotation = newRotation;
                }
                else {
                    transform.localRotation = newRotation;
                }
            }

            // Scale
            // -----

            if ( scale.isEnabled ) {
                // Get the master's position
                Vector3 newScale = ( scale.masterCoordinateSpace == CoordinateSpace.World ) ? masterTransform.lossyScale : masterTransform.localScale;
                // Apply offset
                if ( scale.applyLocalOffset ) {
                    newScale = newScale + _initialScaleLocal;
                }
                if ( scale.applyWorldOffset ) {
                    newScale = newScale + _initialScaleWorld;
                }
                // Set
                if ( scale.targetCoordinateSpace == CoordinateSpace.World ) {
                    Debug.LogError( "Motion cloner can't clone scale to World Space. Sorry" );
                }
                else {
                    transform.localScale = newScale;
                }
            }
        }

    }

}
