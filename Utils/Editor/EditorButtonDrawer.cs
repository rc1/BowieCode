using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System;
using System.Reflection;

namespace BowieCode {

	[CustomPropertyDrawer (typeof (EditorButtonAttribute))]
	public class EditorButtonDrawer : PropertyDrawer {

		// Method & instance
		object targetObject;
		MethodInfo methodInfo;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var editorButtonAttribute = attribute as EditorButtonAttribute;

			UpdateTargetAndMethodInfo( property );

			if ( methodInfo == null ) {
				EditorGUI.HelpBox( position, string.Format( "EditorButton: Method '{0}' not found", editorButtonAttribute.methodName ), MessageType.Warning );
				return;
			}

			EditorGUI.BeginDisabledGroup( !property.FindPropertyRelative( "isEnabled" ).boolValue );

			if ( GUI.Button( position, editorButtonAttribute.buttonTitle == null ? label.text : editorButtonAttribute.buttonTitle ) ) {
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
				var editorButtonAttribute = attribute as EditorButtonAttribute;
				targetObject = property.serializedObject.targetObject;
				methodInfo = targetObject.GetType().GetMethod( editorButtonAttribute.methodName );
			}
		}
	}
}
