using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BowieCode {

	[CustomEditor(typeof(GridRepeater))]
	public class GridRepeaterEditor : Editor {

		public override void OnInspectorGUI() {
			GridRepeater target = (GridRepeater)target;

			DrawDefaultInspector ();

			if ( GUILayout.Button( "Generate" ) ) {
				target.DoGenerateGrid();
			}

		}
	}

}
