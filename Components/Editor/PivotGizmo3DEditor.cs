using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BowieCode {

	[CustomEditor(typeof(PivotGizmo3D))]
	public class PivotGizmo3DEditor : Editor {
		
		public override void OnInspectorGUI() {
			
			PivotGizmo3D instance = (PivotGizmo3D)target;

			serializedObject.Update();

			EditorGUI.BeginDisabledGroup( true );
			SerializedProperty prop = serializedObject.FindProperty( "m_Script" );
			EditorGUILayout.PropertyField(prop, true, new GUILayoutOption[0]);
			EditorGUI.EndDisabledGroup();

			EditorGUILayout.PropertyField( serializedObject.FindProperty( "showOnSelected" ) );
			EditorGUILayout.PropertyField( serializedObject.FindProperty( "arrowSize" ) );
			EditorGUILayout.PropertyField( serializedObject.FindProperty( "useDefaultColor" ) );

			if ( !serializedObject.FindProperty( "useDefaultColor" ).boolValue ) {
				EditorGUILayout.PropertyField( serializedObject.FindProperty( "color" ) );
			} else {
				EditorGUILayout.PropertyField( serializedObject.FindProperty( "alpha" ) );
			}

			serializedObject.ApplyModifiedProperties();


		}
	}
}
