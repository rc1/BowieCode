using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace BowieCode {

	/// <summary>
	/// Binds a list of cameras to a UI.Dropdown
	/// </summary>
	[AddComponentMenu("BowieCode/Dropdown Camera Selector")]
	public class DropdownCameraSelector : MonoBehaviour {

		public List<Camera> cameras;

		public Dropdown dropdown;

		public void Awake () {
			SwitchCamera();

			dropdown.ClearOptions();

			dropdown.AddOptions( cameras.Select( camera => camera.gameObject.name ).ToList() );

			dropdown.onValueChanged.AddListener( (int index) => {
				SwitchCamera();
			});
		}

		public void SwitchCamera () {
			SwitchCamera( dropdown.value );
		}

		public void SwitchCamera ( int cameraIndex ) {
			for ( int i = 0; i < cameras.Count; i++ ) {
				cameras[ i ].gameObject.SetActive( cameraIndex == i );
			}
		}

	}
}
