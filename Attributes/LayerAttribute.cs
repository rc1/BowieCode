using UnityEngine;

namespace BowieCode {

	/// <summary>
	/// Creates a Layer dropdown for an int property. Usage with camera: `camera.cullingMask = 1 \<\< layerMask` 
	/// </summary>
	public class LayerAttribute : PropertyAttribute {

		public LayerAttribute () { }
	}

}