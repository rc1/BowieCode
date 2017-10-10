using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BowieCode {
    /// <summary>
    /// This manager displays notification on the screen
    /// handy for debugging or displaying connection errors
    /// </summary>
    public class DebugNotificationManager : MonoBehaviour {

        /// <summary>
        /// Draws the notifications on the screen
        /// </summary>
        public bool disableNotifications = true;
    
        [Header("Colors")]
        public Color infoColor = Color.cyan;
        public Color warningColor = Color.yellow;
        public Color errorColor = Color.red;

        public class Message {
            public enum Severity {
                Info,
                Warning,
                Error
            }

            public Severity severity = Severity.Info;
            public float keepForSeconds = -1.0f; // lasts forever
            public string text = string.Empty;
        }
    
        private List<Message> _messages = new List<Message>();
    
        private void Awake () {
            DefaultInstance<DebugNotificationManager>.Set( this );
        }
    
        /// <summary>
        /// Adds a message to the default instance if/when it is set
        /// </summary>
        /// <param name="message"></param>
        public static void TryAdd ( Message message ) {
            DefaultInstance<DebugNotificationManager>.WhenSet( d => d.Add( message ));
        }
    
        /// <summary>
        /// Removes a message to the default instance if/when it is set
        /// </summary>
        /// <param name="message"></param>
        public static void TryRemove ( Message message ) {
            DefaultInstance<DebugNotificationManager>.WhenSet( d => d.Remove( message ));
        }

        /// <summary>
        /// Adds a message
        /// </summary>
        /// <param name="message"></param>
        public void Add ( Message message ) {
            // Add it to the messages
            _messages.Add( message );

            // Remove it after the duration
            StartCoroutine( RemoveLater( message ) );
        }

        private IEnumerator RemoveLater ( Message message ) {
            yield return new WaitForSeconds( message.keepForSeconds );
            Remove( message );
        }

        /// <summary>
        /// Adds a message to the display
        /// </summary>
        /// <param name="text">The text of the message</param>
        /// <param name="severity">Affects the color of the message</param>
        /// <param name="keepForSeconds">Duration the message stays on screen. Set to 0.0f to keep the message there until remove using Remove</param>
        /// <returns></returns>
        public Message Add ( string text, Message.Severity severity = Message.Severity.Info, float keepForSeconds = -1.0f ) {
        
            // Create a message
            var message = new Message();
            message.severity = severity;
            message.text = text;
            message.keepForSeconds = keepForSeconds;

            Add( message );

            return message;
        }

        /// <summary>
        /// Removes the message from the display
        /// </summary>
        /// <param name="message">The message to be removed</param>
        public void Remove ( Message message ) {
            _messages = _messages.Where( m => m != message ).ToList();
        }

        /// <summary>
        /// Draws the messages
        /// </summary>
        private void OnGUI () {
        
            if ( disableNotifications ) return;

            // Display each message
            _messages.ForEach( message => {
                switch ( message.severity ) {
                    case Message.Severity.Info:
                        GUI.color = infoColor;
                        break;
                    case Message.Severity.Warning:
                        GUI.color = warningColor;
                        break;
                    default:
                        GUI.color = errorColor;
                        break;
                }

                GUI.skin.box.border.bottom = 10;
                GUI.skin.box.alignment = TextAnchor.UpperLeft;
                GUILayout.Box( message.text, GUILayout.ExpandWidth(true) );
            } );
        
        }

    }
}