using System;
using UnityEngine;

namespace BowieCode {

    [RequireComponent( typeof(Camera) )]
    [ExecuteInEditMode]
    public class CameraFader : MonoBehaviour {

        [Range( 0.0f, 1.0f )]
        public float fadeAmount = 0.0f;

        public Texture2D texture;

        [Header( "Generate Texture" )]
        public Color generateTextureWithColor = Color.black;

        [InspectorButton( MethodName = "CreateTexture", ButtonText = "Create Texture" )]
        public InspectorButton createTextureButton;

        private Camera _camera;

        private void Awake () {
            _camera = GetComponent<Camera>();
        }

        private void OnGUI () {
            // Return if there is not texture or the camera isn't faded
            if ( texture == null || Math.Abs( fadeAmount ) < 0.0001f ) return;

            GUI.color = new Color( 0, 0, 0, fadeAmount );
            GUI.DrawTexture( new Rect( _camera.pixelRect.position.x, _camera.pixelRect.position.y, _camera.pixelWidth, _camera.pixelHeight ),
                             texture );
        }

        public void CreateTexture () {
            // Create the texture
            texture = new Texture2D( 2, 2, TextureFormat.ARGB32, false );

            // set the pixel values
            texture.SetPixel( 0, 0, generateTextureWithColor );
            texture.SetPixel( 1, 0, generateTextureWithColor );
            texture.SetPixel( 0, 1, generateTextureWithColor );
            texture.SetPixel( 1, 1, generateTextureWithColor );

            // Apply all SetPixel calls
            texture.Apply();
        }
    }

}