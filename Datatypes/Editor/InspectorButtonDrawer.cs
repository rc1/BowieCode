using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System;
using System.Reflection;

namespace BowieCode {

    [CustomPropertyDrawer( typeof(InspectorButtonAttribute) )]
    public class InspectorButtonDrawer : PropertyDrawer {

        // Method & instance
        object targetObject;

        MethodInfo methodInfo;

        public override void OnGUI ( Rect position, SerializedProperty property, GUIContent label ) {
            var editorButtonAttribute = attribute as InspectorButtonAttribute;

            UpdateTargetAndMethodInfo( property );

            if ( methodInfo == null ) {
                EditorGUI.HelpBox( position,
                                   string.Format( "InspectorButton: Public method '{0}' not found",
                                                  editorButtonAttribute.MethodName ), MessageType.Warning );
                return;
            }

            bool isDisabled;
            isDisabled = !property.FindPropertyRelative( "isEnabled" ).boolValue;
            isDisabled = isDisabled
                ? isDisabled
                : ( editorButtonAttribute.PlayModeOnly && !EditorApplication.isPlaying );

            EditorGUI.BeginDisabledGroup( isDisabled );

            if ( GUI.Button( position,
                             editorButtonAttribute.ButtonText == null
                                 ? label.text
                                 : editorButtonAttribute.ButtonText ) ) {
                methodInfo.Invoke( targetObject, null );
            }

            EditorGUI.EndDisabledGroup();

        }

        public override float GetPropertyHeight ( SerializedProperty property, GUIContent label ) {

            UpdateTargetAndMethodInfo( property );

            if ( methodInfo != null ) {
                return EditorGUIUtility.singleLineHeight;
            } else {
                return EditorGUIUtility.singleLineHeight * 1.5f;
            }

        }

        void UpdateTargetAndMethodInfo ( SerializedProperty property ) {

            // Get the target object to involve the method 
            // and the MethodInfo on that method

            // First check if the method belongs to the serialzed objects property
            // It may belong to another serialzable object of that property

            if ( targetObject == null ) {

                // Set the initial target
                targetObject = property.serializedObject.targetObject;

                // Get the path of the object
                string[] path = property.propertyPath.Split( '.' );

                // Get the parent 
                path = path.Take( path.Count() > 0 ? path.Count() - 1 : 0 ).ToArray();

                // If it's nested, update the target object
                foreach ( string pathNode in path ) {
                    targetObject = targetObject.GetType().GetField( pathNode ).GetValue( targetObject );
                }
                
                // Get the method info
                var editorButtonAttribute = attribute as InspectorButtonAttribute;
                if ( editorButtonAttribute != null ) {
                    methodInfo = targetObject.GetType().GetMethod( editorButtonAttribute.MethodName );
                }

            }

            // Get the path of the object
            //			string[] path = property.propertyPath.Split( '.' );
            //			// Remove itself 
            //			path = path.Take(path.Count() > 0 ? path.Count() - 1 : 0).ToArray();
            //
            //			bool belongsToMonobehaviour = path.Length == 0;
            //			
            //			targetObject = property.serializedObject.targetObject;
            //			
            //			foreach (string pathNode in path)
            //			{
            //				targetObject = targetObject.GetType().GetField(pathNode).GetValue(targetObject);
            //			}
            //			
            //			Debug.LogFormat( "The inspector is for type {0}. My feildInfo" +
            //			                 "s type is {1}. I found {2}. My Path {3}. I am belong to the monobehavious {4}", 
            //			                 property.serializedObject.targetObject.GetType(),
            //			                 fieldInfo.FieldType,
            //			                 targetObject.GetType(),
            //			                 property.propertyPath,
            //			                 belongsToMonobehaviour );

            //			if ( targetObject == null ) {
            //				
            //				// Debug.Log( fieldInfo.Name );
            //
            //				if ( property.serializedObject.FindProperty( fieldInfo.Name ) != null ) {
            //					// This attribute refers a property in the monobehaviour 
            //					Debug.Log( string.Format( "fieldInfo.Name: {0}", fieldInfo.Name ) );
            //					Debug.Log( string.Format( "Property: {0}",
            //					                          property.serializedObject.FindProperty( fieldInfo.Name ).serializedObject ) );
            //
            //					var editorButtonAttribute = attribute as InspectorButtonAttribute;
            //					targetObject = property.serializedObject.targetObject;
            //					methodInfo = targetObject.GetType().GetMethod( editorButtonAttribute.MethodName );
            //				}
            //			} else {
            //				Debug.Log( string.Format( "Couldn't find: {0}", fieldInfo.Name ) );
            //				// Debug.Log( string.Format( "So: {0}", ) );
            //			}
            //
            //		}
            //
            //		//			if ( targetObject == null ) {
            ////				var editorButtonAttribute = attribute as InspectorButtonAttribute;
            ////				targetObject = property.serializedObject.targetObject;
            ////				methodInfo = targetObject.GetType().GetMethod( editorButtonAttribute.MethodName );
            ////			}

        }
    }
}