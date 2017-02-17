using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System;
using System.Reflection;

namespace BowieCode {

	[CustomPropertyDrawer (typeof (InspectorButtonAttribute))]
	public class InspectorButtonDrawer : PropertyDrawer {

		// Method & instance
		object targetObject;
		MethodInfo methodInfo;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var editorButtonAttribute = attribute as InspectorButtonAttribute;

			UpdateTargetAndMethodInfo( property );

			if ( methodInfo == null ) {
				EditorGUI.HelpBox( position, string.Format( "InspectorButton: Public method '{0}' not found", editorButtonAttribute.MethodName ), MessageType.Warning );
				return;
			}

			bool isDisabled;
			isDisabled = !property.FindPropertyRelative( "isEnabled" ).boolValue;
			isDisabled = isDisabled ? isDisabled : (editorButtonAttribute.PlayModeOnly && !EditorApplication.isPlaying);

			EditorGUI.BeginDisabledGroup( isDisabled );

			if ( GUI.Button( position, editorButtonAttribute.ButtonText == null ? label.text : editorButtonAttribute.ButtonText ) ) {
				methodInfo.Invoke( property.serializedObject.targetObject, null );
			}

			EditorGUI.EndDisabledGroup();

		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {

			UpdateTargetAndMethodInfo( property );

			if ( methodInfo != null ) {
				return EditorGUIUtility.singleLineHeight;
			} else {
				return EditorGUIUtility.singleLineHeight * 1.5f ;
			}

		}

		void UpdateTargetAndMethodInfo ( SerializedProperty property ) {
			if ( targetObject == null ) {
				var editorButtonAttribute = attribute as InspectorButtonAttribute;
				targetObject = property.serializedObject.targetObject;
				methodInfo = targetObject.GetType().GetMethod( editorButtonAttribute.MethodName );
			}
		}
	}
}
