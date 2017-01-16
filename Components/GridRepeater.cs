using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BowieCode {

	/// <summary>
	/// Component to layout out a series of gameobjects.
	/// </summary>
	public class GridRepeater : MonoBehaviour {

		// Types
		// =====

		[System.Serializable]
		public class GridSettings {
			public Vector3 count = new Vector3();
			public float spacing = 1.0f;
		}

		public const string CONTAINER_NAME = "[dynamic]";

		// Config
		// ======

		public GameObject prefab;
		public GridSettings gridSettings;

		// Static Methods
		// ==============
		/// <summary>
		/// Clones the prefan into container with the grid settings.
		/// </summary>
		/// <param name="prefab">Prefab.</param>
		/// <param name="container">Container.</param>
		/// <param name="gridSettings">Grid settings.</param>
		public static void CloneIntoContainer ( GameObject prefab, Transform container, GridSettings gridSettings ) {

			Vector3 anchor = new Vector3( gridSettings.count.x * gridSettings.spacing / -2.0f,
			                             gridSettings.count.y * gridSettings.spacing / -2.0f,
			                             gridSettings.count.z * gridSettings.spacing / -2.0f);

			for ( int x = 0; x < gridSettings.count.x; x++ ) {
				for ( int y = 0; y < gridSettings.count.y; y++ ) {
					for ( int z = 0; z < gridSettings.count.z; z++ ) {;
						GameObject clone;
#if UNITY_EDITOR
						clone = PrefabUtility.InstantiatePrefab( prefab ) as GameObject;
#else
						clone = Instantiate( prefab );
#endif
						clone.transform.parent = container;
						clone.transform.position = anchor + new Vector3( x * gridSettings.spacing, y * gridSettings.spacing, z * gridSettings.spacing );
					}
				}
			}
		}

		// Methonds
		// ========

		/// <summary>
		/// Generate's the grid on this gameobjt.
		/// </summary>
		public void DoGenerateGrid () {
			if ( !HasGridContainer() ) {
				CreateGridContainer();
			} else {
				ClearGridContainer();
			}
			CloneIntoContainer( prefab, GetGridContainer(), gridSettings );
		}

		/// <summary>
		/// Clears the grid container.
		/// </summary>
		void ClearGridContainer () {
			if ( HasGridContainer() ) {
				Transform container = GetGridContainer();
				for(int i = container.childCount - 1; i >= 0; i--)
				{
#if UNITY_EDITOR
					DestroyImmediate( container.GetChild( i ).gameObject );
#else
					Destroy( container.GetChild( i ).gameObject );
#endif
				}
			}
		}

		/// <summary>
		/// Creates the grid container.
		/// </summary>
		void CreateGridContainer () {
			var container = new GameObject();
			container.transform.name = CONTAINER_NAME;
			container.transform.parent = transform;
		}

		/// <summary>
		/// Gets the grid container.
		/// </summary>
		/// <returns>The grid container.</returns>
		Transform GetGridContainer () {
			return transform.Find( CONTAINER_NAME );
		}

		/// <summary>
		/// Determines whether this instance has grid container.
		/// </summary>
		/// <returns><c>true</c> if this instance has grid container; otherwise, <c>false</c>.</returns>
		bool HasGridContainer () {
			return transform.Find( CONTAINER_NAME ) != null;
		}

	}
		
}