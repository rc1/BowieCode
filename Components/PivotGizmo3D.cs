using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BowieCode {

	/// <summary>
	/// Draws customisable axises like the move tool when the object is not selected.
	/// </summary>
	[AddComponentMenu("BowieCode/Pivot Gizmo 3D")]
	public class PivotGizmo3D : MonoBehaviour {

		Transform _transform;

		public float arrowSize = 0.25f;
		public bool useDefaultColor = true;
		public Color color = Color.cyan;
		[Range(0.0f, 1.0f)]
		public float alpha = 1.0f;
		public bool showOnSelected = false;


#if UNITY_EDITOR
		public void OnDrawGizmos () {

			// Only when selected
			if ( !showOnSelected ) {
				if ( UnityEditor.Selection.activeGameObject == this.gameObject ) {
					return;
				}
			}

			// Cache transform
			if ( _transform == null ) {
				_transform = transform;
			}

			Handles.color = useDefaultColor ? ApplyAlpha( Handles.xAxisColor, alpha ) : color;
			Handles.ArrowHandleCap( 0, _transform.transform.position, _transform.transform.rotation * Quaternion.Euler( 0, 90, 0 ), arrowSize,  EventType.Layout );

			Handles.color = useDefaultColor ? ApplyAlpha( Handles.yAxisColor, alpha ) : color;
			Handles.ArrowHandleCap( 0, _transform.transform.position, _transform.transform.rotation * Quaternion.Euler( -90, 0, 0 ), arrowSize,  EventType.Layout );

			Handles.color = useDefaultColor ? ApplyAlpha( Handles.zAxisColor, alpha ) : color;
			Handles.ArrowHandleCap( 0, _transform.transform.position, _transform.transform.rotation, arrowSize, EventType.Layout );
		}
#endif

		public static Color ApplyAlpha ( Color c, float a ) {
			c.a = a;
			return c;
		}

	}

}
