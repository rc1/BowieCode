using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BowieCode {

	[CustomPropertyDrawer (typeof (Vector3ComponentSelection))]
	public class Vector3ComponentSelectionDrawer : PropertyDrawer {

		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {

			var all = property.FindPropertyRelative( "all" );
			var x = property.FindPropertyRelative( "x" );
			var y = property.FindPropertyRelative( "y" );
			var z = property.FindPropertyRelative( "z" );

			var prefixPosition = position;
			prefixPosition.width = EditorGUIUtility.labelWidth - ( EditorGUI.indentLevel * 15.0f );

			var quarterRemainingSpace = ( position.width - prefixPosition.width ) / 4.0f;

			var allPosition = position;
			allPosition.width = quarterRemainingSpace;
			allPosition.x += prefixPosition.width;

			var xPosition = allPosition;
			xPosition.x += quarterRemainingSpace;

			var yPosition = xPosition;
			yPosition.x += quarterRemainingSpace;

			var zPosition = yPosition;
			zPosition.x += quarterRemainingSpace;

			EditorGUI.PrefixLabel( prefixPosition, label );
			all.boolValue = EditorGUI.ToggleLeft( allPosition, "all", all.boolValue );

			EditorGUI.BeginDisabledGroup( all.boolValue );

			x.boolValue = EditorGUI.ToggleLeft( xPosition, "x", x.boolValue );
			y.boolValue = EditorGUI.ToggleLeft( yPosition, "y", y.boolValue );
			z.boolValue = EditorGUI.ToggleLeft( zPosition, "z", z.boolValue );

			EditorGUI.EndDisabledGroup();
		}

	}

}