using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace BowieCode {

	/// <summary>
	/// Creates an inspector button in the inspector when combined with the [EditorButton] attribute
	/// </summary>
	[System.Serializable]
	public class InspectorButton {

		/// <summary>
		/// Enables or disables the button in the inspector
		/// </summary>
		public bool isEnabled = true;

	}
}
