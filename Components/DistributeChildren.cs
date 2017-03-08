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

		public Vector3 a = new Vector3( -1.0f, 0.0f, 0.0f );
		public Vector3 b = new Vector3( 1.0f, 0.0f, 0.0f );

#if UNITY_EDITOR
		[InspectorButton(MethodName="RedistributeChildren",ButtonText="Distribute Children")]
		public InspectorButton distributeButton;
#endif

		/// <summary>
		/// Preform the distribution of the children.
		/// </summary>
		public void RedistributeChildren () {
			for ( float i = 0.0f; i < transform.childCount; i++ ) {
				Vector3 pos = Vector3.Lerp( a + transform.position, b + transform.position, i / ( transform.childCount - 1.0f ) );
				transform.GetChild( (int)i ).position = pos;
			}
		}

		/// <summary>
		/// Draw a line with the points
		/// </summary>
		void OnDrawGizmosSelected () {
			Gizmos.color = Color.cyan;
			Gizmos.DrawLine( a + transform.position, b + transform.position );
			Gizmos.color = Color.yellow;
			for ( float i = 0.0f; i < transform.childCount; i++ ) {
				Vector3 pos = Vector3.Lerp( a, b, i / ( transform.childCount - 1.0f ) );
				Gizmos.DrawSphere( transform.position + pos, 0.1f );
			}
		}
			
	}

}
