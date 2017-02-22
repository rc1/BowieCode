using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BowieCode {

	[CustomPropertyDrawer (typeof (ShapedRange))]
	public class ShapedRangeDrawer : PropertyDrawer {

		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {

			var shape = property.FindPropertyRelative( "shape" );

			var valuePosition = position;
			var shapePosition = position;

			shapePosition.width = 50.0f;
			shapePosition.x = position.xMax - shapePosition.width;
			valuePosition.width = position.width - shapePosition.width  - 3.0f;

			if ( shape.enumValueIndex == (int) (ShapedRange.Shape) ShapedRange.Shape.Constant ) {
				var constant = property.FindPropertyRelative( "constant" );
				EditorGUI.PropertyField( valuePosition, constant, label );
				// constant.floatValue = EditorGUI.FloatField( valuePosition, label, constant.floatValue );
			} else if ( shape.enumValueIndex == (int) (ShapedRange.Shape) ShapedRange.Shape.Curve ) {
				var curve = property.FindPropertyRelative( "curve" );
				EditorGUI.PropertyField( valuePosition, curve, label );
			} else if ( shape.enumValueIndex == (int) (ShapedRange.Shape) ShapedRange.Shape.Linear ) {
				var linear = property.FindPropertyRelative( "linear" );
				var prefixShape = valuePosition;
				prefixShape.width = EditorGUIUtility.labelWidth;
				var minShape = valuePosition;
				minShape.x = prefixShape.xMax;
				var maxShape = minShape;
				minShape.width = (valuePosition.width - EditorGUIUtility.labelWidth - 4.0f) / 2.0f;
				maxShape.x += minShape.width + 2.0f;
				maxShape.width = minShape.width;
				EditorGUI.PrefixLabel( prefixShape, label );
				EditorGUIUtility.labelWidth = 26.0f;
				float min = EditorGUI.FloatField( minShape, "Min", linear.vector2Value.x );
				float max = EditorGUI.FloatField( maxShape, "Max", linear.vector2Value.y );
				linear.vector2Value = new Vector2( min, max );
			}
			                                        
			shape.enumValueIndex = (int)(ShapedRange.Shape)EditorGUI.EnumPopup(
				shapePosition,
				(ShapedRange.Shape)shape.enumValueIndex );
		}
	}

}