using System.Linq;
using UnityEngine;
using UnityEditor;

namespace BowieCode {

	[CustomPropertyDrawer (typeof (SortingLayerAttribute))]
	public class SortingLayerDrawer : PropertyDrawer {
		
		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {

			if ( property.propertyType == SerializedPropertyType.Integer ) {
				var layers = SortingLayer.layers;
				var names = layers.Select( l => l.name ).ToArray();
				var layerValue = SortingLayer.GetLayerValueFromID( property.intValue );
				var idx = EditorGUI.Popup( position, label.text, layerValue, names );
				property.intValue = layers[ idx ].id;
			} else {
				EditorGUI.LabelField( position, label.text, "Use SortingLayerAttribute with an int." );
			}
		}
	}

}