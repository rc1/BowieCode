using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BowieCode {
	
	#if UNITY_EDITOR_OSX

	[ExecuteInEditMode]
	public class SceneRecorder : MonoBehaviour {
		
		// The folder to contain our screenshots.
		// If the folder exists we will append numbers to create an empty folder.
		public string folder = "";

		public int frameRate = 25;

		public bool enableRecording = false;

		public int superSizeFactor = 1;

		void OnEnable() {
			if ( folder == "" ) {
				folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/Desktop/" + SceneManager.GetActiveScene().name;
			}
		}

		void Start() {

			if ( enableRecording ) {

				// Keep it going in the background
				Application.runInBackground = true;

				// Set the playback framerate (real time will not relate to game time after this).
				Time.captureFramerate = frameRate;

				// Create the folder
				System.IO.Directory.CreateDirectory( folder );
			
			}
		}


		void Update() {

			if ( enableRecording ) {

				// Append largeVideo to folder name (format is '0005 shot.png"')
				string name = string.Format( "{0}/frame-{1:D04} shot.png", folder, Time.frameCount );

				// Capture the screenshot to the specified file.
				ScreenCapture.CaptureScreenshot( name, superSizeFactor );
			}
		} 
	}
	
	#endif

}