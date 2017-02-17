using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using BowieCode;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BowieCode {

	/// <summary>
	/// Creates instances of a prefab in the scene at the position 
	/// of game objects with a certain tag. Can be undone when 
	/// triggered in the editor. Instances can be parented
	/// with the game object at the tag, a container or the 
	/// root of the scene.
	/// </summary>
	[AddComponentMenu("BowieCode/Instantiate At Tag")]
	public class InstantiateAtTag  : MonoBehaviour {

		public enum ParentingMode {
			AppendToTarget,
			AppendToContainer,
			AppendToSceneRoot
		}

		/// <summary>
		/// How the instance is parented
		/// </summary>
		[Header("Options")]
		public ParentingMode instanceParent = ParentingMode.AppendToContainer;

		/// <summary>
		/// Copy the position of the target to the instance when the parenting mode is 
		/// <see cref="ParentingMode.AppendToContainer;" /> or 
		/// <see cref="ParentingMode.AppendToSceneRoot;" />.
		/// </summary>
		public bool copyPosition = true;
		/// <summary>
		/// Copy the rotation of the target to the instance when the parenting mode is 
		/// <see cref="ParentingMode.AppendToContainer;" /> or 
		/// <see cref="ParentingMode.AppendToSceneRoot;" />.
		/// </summary>
		public bool copyRotation = true;

		/// <summary>
		/// The parent which will be used for the instance
		/// <see cref="ParentingMode.AppendToContainer;" />.
		/// </summary>
		public Transform container;

		[Header("Target")]
		[Tag]
		public string targetTag = "";

		[Header("Prefab & Instance Container")]
		public GameObject prefab;

		[Space(10)]

		[InspectorButton(MethodName="CreateInstances",ButtonText="Create Instances")]
		public InspectorButton createButton;
			
		public void CreateInstances () {
		
			GameObject
				.FindGameObjectsWithTag( targetTag )
				.ToList()
				.ForEach( target => {
					
				var clone = EditorSafe.CreateFromPrefab( prefab );

				Transform cloneTransform = clone.transform;
				Transform targetTransform = target.transform;

				// Parent
				if ( instanceParent == ParentingMode.AppendToContainer ) {
					cloneTransform.parent = container;
				} else if ( instanceParent == ParentingMode.AppendToTarget ) {
					cloneTransform.parent = targetTransform;
				} else if ( instanceParent == ParentingMode.AppendToSceneRoot ) {

				}

				// Copy rotations & Position
				if ( instanceParent == ParentingMode.AppendToContainer || 
				    instanceParent == ParentingMode.AppendToSceneRoot ) {
					if ( copyPosition ) { cloneTransform.position = targetTransform.position; }
					if ( copyRotation ) { cloneTransform.localRotation = targetTransform.rotation; }
				}


#if UNITY_EDITOR
				// Add to undo
				Undo.RegisterCreatedObjectUndo( clone, "Create instance" );
#endif
					
			});

		}

	}

}