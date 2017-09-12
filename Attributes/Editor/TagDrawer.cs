using UnityEngine;
using UnityEditor;

namespace BowieCode {

	[CustomPropertyDrawer (typeof (TagAttribute))]
	public class TagDrawer : PropertyDrawer {
		
		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {

			if ( property.propertyType == SerializedPropertyType.String )
				property.stringValue = EditorGUI.TagField( position, label, property.stringValue );
			else
				EditorGUI.LabelField (position, label.text, "Use TagAttribute with int.");
		}
	}

}