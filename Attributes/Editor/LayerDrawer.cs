using UnityEngine;
using UnityEditor;

namespace BowieCode {

	[CustomPropertyDrawer( typeof( LayerAttribute ) )]
	public class LayerDrawer : PropertyDrawer {

		public override void OnGUI ( Rect position, SerializedProperty property, GUIContent label ) {

			if ( property.propertyType == SerializedPropertyType.Integer )
				property.intValue = EditorGUI.LayerField( position, label, property.intValue );
			else
				EditorGUI.LabelField( position, label.text, "Use Layer with int." );
		}
	}

}