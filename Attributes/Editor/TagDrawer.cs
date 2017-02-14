using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BowieCode {

	[CustomPropertyDrawer (typeof (TagAttribute))]
	public class TagDrawer : PropertyDrawer {
		
		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {

			// First get the attribute since it contains the range for the slider
			// TagAttribute tag = attribute as TagAttribute;

			// Now draw the property as a Slider or an IntSlider based on whether it's a float or integer.
			if ( property.propertyType == SerializedPropertyType.String )
				property.stringValue = EditorGUI.TagField( position, label, property.stringValue );
			else
				EditorGUI.LabelField (position, label.text, "Use Tag with string.");
		}
	}

}