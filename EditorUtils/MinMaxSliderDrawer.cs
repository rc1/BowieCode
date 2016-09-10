using UnityEngine;
using UnityEditor;

namespace BowieCode {

    /// <summary>
    /// Draws the min max slider
    /// </summary>
    [CustomPropertyDrawer( typeof( MinMaxSliderAttribute ) )]
    class MinMaxSliderDrawer : PropertyDrawer {

        private const float FIELD_WIDTH = 32f;
        private const float SPACE_WIDTH = 4f;

        public override void OnGUI ( Rect position, SerializedProperty property, GUIContent label ) {
            if ( property.propertyType == SerializedPropertyType.Vector2 ) {
                Vector2 range = property.vector2Value;
                float min = range.x;
                float max = range.y;
                var attr = attribute as MinMaxSliderAttribute;
                EditorGUI.BeginChangeCheck();
                position = EditorGUI.PrefixLabel( position, -1, label );
                var sliderPosition = position;
                if ( attr.showFloatFields ) {
                    sliderPosition.x += FIELD_WIDTH + SPACE_WIDTH;
                    sliderPosition.width -= 2f * ( FIELD_WIDTH + SPACE_WIDTH );
                    var minPosition = position;
                    minPosition.width = FIELD_WIDTH;
                    min = EditorGUI.FloatField( minPosition, min );
                    var maxPosition = minPosition;
                    maxPosition.x += position.width - FIELD_WIDTH;
                    max = EditorGUI.FloatField( maxPosition, max );
                }
                EditorGUI.MinMaxSlider( sliderPosition, ref min, ref max, attr.min, attr.max );
                if ( EditorGUI.EndChangeCheck() ) {
                    range.x = min;
                    range.y = max;
                    property.vector2Value = range;
                }
            }
            else {
                EditorGUI.LabelField( position, label, "Use only with Vector2" );
            }
        }
    }
}