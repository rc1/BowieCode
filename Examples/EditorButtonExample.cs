using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BowieCode {

	public class EditorButtonExample : MonoBehaviour {

		// Buttons

		// Button text will be the name of the button property
		[EditorButton("OnToggledButton")]
		public EditorButton toggledButton;

		[Space]

		// Button text will be the secord parameter of the attribute
		[EditorButton("OnSetOn", "Enable Button")]
		public EditorButton setOnButton;

		[EditorButton("OnSetOff", "Disable Button")]
		public EditorButton setOffButton;

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
