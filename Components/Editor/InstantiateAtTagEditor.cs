using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BowieCode {

	[CustomEditor(typeof(InstantiateAtTag))]
	public class InstantiateAtTagEditor : Editor {

		public override void OnInspectorGUI() {

			serializedObject.Update();

			EditorGUI.BeginDisabledGroup( true );
			SerializedProperty prop = serializedObject.FindProperty( "m_Script" );
			EditorGUILayout.PropertyField(prop, true, new GUILayoutOption[0]);
			EditorGUI.EndDisabledGroup();

			var parentingMode = serializedObject.FindProperty( "instanceParent" );

			EditorGUILayout.PropertyField( parentingMode );

			if ( (InstantiateAtTag.ParentingMode) parentingMode.enumValueIndex == InstantiateAtTag.ParentingMode.AppendToContainer ) {
				EditorGUILayout.PropertyField( serializedObject.FindProperty( "container" ) );
			}

			if ( (InstantiateAtTag.ParentingMode)parentingMode.enumValueIndex == InstantiateAtTag.ParentingMode.AppendToContainer || 
			    (InstantiateAtTag.ParentingMode)parentingMode.enumValueIndex == InstantiateAtTag.ParentingMode.AppendToSceneRoot ) {
				EditorGUILayout.PropertyField( serializedObject.FindProperty( "copyPosition" ) );
				EditorGUILayout.PropertyField( serializedObject.FindProperty( "copyRotation" ) );
			}

			EditorGUILayout.PropertyField( serializedObject.FindProperty( "targetTag" ) );
			EditorGUILayout.PropertyField( serializedObject.FindProperty( "prefab" ) );
			EditorGUILayout.PropertyField( serializedObject.FindProperty( "createButton" ) );

			serializedObject.ApplyModifiedProperties();

			EditorGUILayout.Space();


		}
	}
}
