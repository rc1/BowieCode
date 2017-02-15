using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace BowieCode {

	/// <summary>
	/// Creates an editor button in the inspector when combined with the [EditorButton] attribute
	/// </summary>
	[System.Serializable]
	public class EditorButton {

		/// <summary>
		/// Enables or disables the button in the inspector
		/// </summary>
		public bool isEnabled = true;

	}
}
