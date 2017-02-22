using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ParentingMode))]
public class ParentingModeDrawer : PropertyDrawer {

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {

		var mode = property.FindPropertyRelative( "mode" );
		var target = property.FindPropertyRelative( "target" );

		var prefixPosition = position;
		prefixPosition.width = EditorGUIUtility.labelWidth;

		var modePosition = position;
		modePosition.x = prefixPosition.xMax;
		modePosition.width = position.width - prefixPosition.width;
		modePosition.height = EditorGUIUtility.singleLineHeight;

		EditorGUI.PrefixLabel( prefixPosition, label );

		EditorGUIUtility.labelWidth = 0.0f;
		mode.intValue = (int)(ParentingMode.ModeType)EditorGUI.EnumPopup( modePosition, (ParentingMode.ModeType)mode.enumValueIndex );

		if ( mode.enumValueIndex == (int)ParentingMode.ModeType.Target ) {
			var targetPositon = modePosition;
			targetPositon.y += EditorGUIUtility.singleLineHeight;
			EditorGUIUtility.labelWidth = 45.0f;
			EditorGUI.PropertyField( targetPositon, target );
		}
		
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
		var mode = property.FindPropertyRelative( "mode" );
		if ( mode.enumValueIndex == (int)ParentingMode.ModeType.Target ) {
			return EditorGUIUtility.singleLineHeight * 2.0f;
		}
		return EditorGUIUtility.singleLineHeight;
	}
}