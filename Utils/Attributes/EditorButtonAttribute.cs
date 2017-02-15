using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace BowieCode {

	/// <summary>
	/// Create a button in the editor for a EditorButton property
	/// </summary>
	public class EditorButtonAttribute : PropertyAttribute {

		// Public setters
		public string methodName;
		public string buttonTitle;

		/// <summary>
		/// Initializes a new instance of the <see cref="BowieCode.EditorButtonAttribute"/> class. The button will use the name of the property as its text.
		/// </summary>
		/// <param name="methodName">The name of the method to be called</param>
		public EditorButtonAttribute( string methodName ) {
			this.methodName = methodName;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BowieCode.EditorButtonAttribute"/> class.
		/// </summary>
		/// <param name="methodName">Method name.</param>
		/// <param name="title">The button text.</param>
		public EditorButtonAttribute ( string methodName, string title ) {
			this.methodName = methodName;
			buttonTitle = title;
		}
	}

}