using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BowieCode;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Destroies all the gameobject's children. Useful for dynamic content. Can be undone in editor mode.
/// </summary>
[AddComponentMenu("BowieCode/Destroy All Children")]
public class DestroyAllChildren : MonoBehaviour {

	[InspectorButton(MethodName="DoDestructionOfChildren",ButtonText="Destroy All Children")]
	public InspectorButton destroyChildrenButton;

	public void DoDestructionOfChildren () {
		var idx = transform.childCount;
		while ( idx-- >= 1 ) {
			try {
				DestoryChild( transform.GetChild( idx ).gameObject );
			} catch ( System.Exception e ) {
				Debug.LogError( "Failed to destory child at index: " + idx );
				throw e;
			}
		}
	}

	void DestoryChild ( GameObject child ) {
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
