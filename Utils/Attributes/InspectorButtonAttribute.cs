using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace BowieCode {

	/// <summary>
	/// Create a button in the inspector for an InspectorButton property
	/// </summary>
	public class InspectorButtonAttribute : PropertyAttribute {

		// Public setters
		public string methodName;
		public string buttonText;

		/// <summary>
		/// Initializes a new instance of the <see cref="BowieCode.InspectorButtonAttribute"/> class. The button will use the name of the property as its text.
		/// </summary>
		/// <param name="methodName">The name of the method to be called</param>
		public InspectorButtonAttribute( string methodName ) {
			this.methodName = methodName;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BowieCode.InspectorButtonAttribute"/> class.
		/// </summary>
		/// <param name="methodName">Method name.</param>
		/// <param name="title">The button text.</param>
		public InspectorButtonAttribute ( string methodName, string text ) {
			this.methodName = methodName;
			buttonText = text;
		}
	}

}