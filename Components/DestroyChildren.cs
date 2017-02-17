using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BowieCode;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Destroy the gameobject children. Useful for dynamic content. Can be undone in editor mode
/// </summary>
[AddComponentMenu("BowieCode/Destroy Children")]
public class DestroyChildren : MonoBehaviour {

	[InspectorButton(MethodName="Do",ButtonText="Destroy Children")]
	public InspectorButton destoryChildrenButton;

	public void Do () {
		var idx = transform.childCount;
		while ( idx-- >= 1 ) {
			try {
				DeleteChild( transform.GetChild( idx ).gameObject );
			} catch ( System.Exception e ) {
				Debug.LogError( "Failed to destory child at index: " + idx );
				throw e;
			}
		}
	}

	void DeleteChild ( GameObject child ) {
#if UNITY_EDITOR
		if ( !EditorApplication.isPlaying ) {
			Undo.DestroyObjectImmediate( child.gameObject );
		} else {
			EditorSafe.Destroy( child.gameObject );
		}
#else
		EditorSafe.Destroy( transform.gameObject );
#endif
	}

}
