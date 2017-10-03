using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

namespace BowieCode {
	#if UNITY_EDITOR_OSX
	
	[AddComponentMenu("Wandering Medow/Utils/Screen Recorder")]
	[CustomEditor(typeof(SceneRecorder))]
	public class SceneRecorderEditor : Editor {
		public override void OnInspectorGUI() {
			SceneRecorder sceneRecorder = (SceneRecorder)target;

			DrawDefaultInspector ();

			if ( GUILayout.Button( "Create Video File" ) ) {

				string filename = string.Format( "{0}-{1}.mp4", BowieTime.GetDayString(), BowieTime.GetTimeString() );

				ProcessStartInfo startInfo = new ProcessStartInfo()
				{
					FileName = "/usr/local/bin/ffmpeg",
					Arguments = "-framerate 25 -pattern_type glob -i '" + sceneRecorder.folder + "/frame-*.png' -vf \"scale=trunc(iw/2)*2:trunc(ih/2)*2\" -c:v libx264 -r 30 -pix_fmt yuv420p " + filename,
					RedirectStandardOutput = true,
					RedirectStandardInput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					WorkingDirectory = sceneRecorder.folder + '/',
				};

				Process process = new Process()
				{
					StartInfo = startInfo,
				};

				process.EnableRaisingEvents = false;
				process.OutputDataReceived += (object sender, DataReceivedEventArgs eventArgs ) => {
					UnityEngine.Debug.Log( eventArgs.Data );
				};

				process.ErrorDataReceived += ( object sender, DataReceivedEventArgs eventArgs ) => {
					UnityEngine.Debug.Log( eventArgs.Data );
				};

				process.Start();

				process.BeginOutputReadLine();
				process.BeginErrorReadLine();

			}

			if ( GUILayout.Button( "Remove Image Files" ) ) {

				ProcessStartInfo startInfo = new ProcessStartInfo()
				{
					FileName = "/bin/rm",
					Arguments = "\"" + sceneRecorder.folder + "/\"frame-*.png",
					RedirectStandardOutput = true,
					RedirectStandardInput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					WorkingDirectory = sceneRecorder.folder + '/',
				};

				Process process = new Process()
				{
					StartInfo = startInfo,
				};

				process.EnableRaisingEvents = false;
				process.OutputDataReceived += (object sender, DataReceivedEventArgs eventArgs ) => {
					UnityEngine.Debug.Log( eventArgs.Data );
				};

				process.ErrorDataReceived += ( object sender, DataReceivedEventArgs eventArgs ) => {
					UnityEngine.Debug.Log( eventArgs.Data );
				};

				process.Start();

				process.BeginOutputReadLine();
				process.BeginErrorReadLine();

			}
		}
	}
	
	#endif
}