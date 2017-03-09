using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BowieCode {

	/// <summary>
	/// Distributes it's children between two points. The two points can be manipulated in the scene view.
	/// </summary>
	public class DistributeChildren : MonoBehaviour {

		public bool point1enabled = true;
		public bool point2enabled = true;

		public Vector3 point1 = new Vector3( -1.0f, 0.0f, 0.0f );
		public Vector3 point2 = new Vector3( 1.0f, 0.0f, 0.0f );

		private int _lastChildCount = -1;

#if UNITY_EDITOR
		[InspectorButton(MethodName="RedistributeChildren",ButtonText="Distribute Children")]
		public InspectorButton distributeButton;
#endif

		/// <summary>
		/// Preform the distribution of the children.
		/// </summary>
		public void RedistributeChildren () {
			if ( transform.childCount > 1 ) {
				return;
			}

			for ( float i = 0.0f; i < transform.childCount; i++ ) {
				Vector3 pos = Vector3.Lerp( point1 + transform.position, point2 + transform.position, i / ( transform.childCount - 1.0f ) );
				transform.GetChild( (int)i ).position = pos;
			}
		}

		/// <summary>
		/// Draw a line with the points
		/// </summary>
		void OnDrawGizmosSelected () {

			// Do an update if we need to
			if ( _lastChildCount != transform.childCount ) {
				RedistributeChildren();
				_lastChildCount = transform.childCount;
			}
			
			Gizmos.color = Color.cyan;
			Gizmos.DrawLine( point1 + transform.position, point2 + transform.position );
			Gizmos.color = Color.yellow;
			for ( float i = 0.0f; i < transform.childCount; i++ ) {
				Vector3 pos = Vector3.Lerp( point1, point2, i / ( transform.childCount - 1.0f ) );
				Gizmos.DrawSphere( transform.position + pos, 0.1f );
			}
		}
			
	}

}
