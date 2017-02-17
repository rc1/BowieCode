using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BowieCode {

	/// <summary>
	/// Has utility methods to preform actions which invokes differently being editor and application/play modes 
	/// </summary>
	public class EditorSafe {

		/// <summary>
		/// Creates a GameObject from a Prefab using `PrefabUtility` in Editor Mode or `MonoBehaviour` in Play Mode
		/// </summary>
		/// <returns>The from prefab.</returns>
		/// <param name="prefab">Prefab.</param>
		public static GameObject CreateFromPrefab ( GameObject prefab ) {

			GameObject clone;
#if UNITY_EDITOR
			if ( EditorApplication.isPlaying ) {
				clone = Object.Instantiate( prefab ) as GameObject;
			} else {
				clone = PrefabUtility.InstantiatePrefab( prefab ) as GameObject;
			}
#else
			clone = Object.Instantiate( prefab ) as GameObject;
#endif
			return clone;
		}

		/// <summary>
		/// Destroy the specified target using `DestroyImmediate` in Editor Mode or `Destroy` in Play Mode
		/// </summary>
		/// <param name="target">Target.</param>
		public static void Destroy ( GameObject target ) {
#if UNITY_EDITOR
			if ( EditorApplication.isPlaying ) {
				Destroy( target );
			} else {
				Object.DestroyImmediate( target );
			}
#else
			Destroy( target );
#endif
		}

	}

}
