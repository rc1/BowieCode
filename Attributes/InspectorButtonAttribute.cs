using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace BowieCode {

	/// <summary>
	/// Create a button in the inspector for an InspectorButton property
	/// </summary>
	public class InspectorButtonAttribute : PropertyAttribute {

		/// <summary>
		/// The name of the method to be invoked.
		/// </summary>
		public string MethodName;
		/// <summary>
		/// Optional text of the button. When not set the MethodName will be used.
		/// </summary>
		public string ButtonText;
		/// <summary>
		/// Disable the button when not in play mode
		/// </summary>
		public bool PlayModeOnly = false;

		public InspectorButtonAttribute() {}

		/// <summary>
		/// Initializes a new instance of the <see cref="BowieCode.InspectorButtonAttribute"/> class. The button will use the name of the property as its text.
		/// </summary>
		/// <param name="methodName">The name of the method to be called</param>
		public InspectorButtonAttribute( string methodName ) {
			MethodName = methodName;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BowieCode.InspectorButtonAttribute"/> class.
		/// </summary>
		/// <param name="methodName">Method name.</param>
		/// <param name="title">The button text.</param>
		public InspectorButtonAttribute ( string methodName, string buttonText ) {
			MethodName = methodName;
			ButtonText = buttonText;
		}
			
	}

}