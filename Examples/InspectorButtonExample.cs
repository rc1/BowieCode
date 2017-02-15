using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BowieCode {

	public class InspectorButtonExample : MonoBehaviour {

		// Buttons

		// Button text will be the name of the button property
		[InspectorButton("OnToggledButton")]
		public InspectorButton toggledButton;

		[Space]

		// Button text will be the secord parameter of the attribute
		[InspectorButton("OnSetOn", "Enable Button")]
		public InspectorButton setOnButton;

		[InspectorButton("OnSetOff", "Disable Button")]
		public InspectorButton setOffButton;

		// Button Handlers

		public void OnSetOff () {
			toggledButton.isEnabled = false;
		}

		public void OnSetOn () {
			toggledButton.isEnabled = true;
		}

		public void OnToggledButton () {
			Debug.Log( "Yay!" );
		}

	}

}
