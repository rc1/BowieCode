using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BowieCode {

	public class InspectorButtonExample : MonoBehaviour {

		// Buttons

		// Button text will be the name of the button property
		[InspectorButton("SayYay")]
		public InspectorButton sayYayButton;

		[Space(10)]

		// Button text will be the second parameter of the attribute
		[InspectorButton("OnSetOn", "Enable Button")]
		public InspectorButton setOnButton;

		[InspectorButton("OnSetOff", "Disable Button")]
		public InspectorButton setOffButton;

		[Space(10)]
		[InspectorButton( MethodName="SayYay", ButtonText="Play Mode Only", PlayModeOnly = true)]
		public InspectorButton playModeBitton;

		// Button Handlers 

		public void OnSetOff () {
			sayYayButton.isEnabled = false;
		}

		public void OnSetOn () {
			sayYayButton.isEnabled = true;
		}

		public void SayYay () {
			Debug.Log( "Yay!" );
		}

	}

}
