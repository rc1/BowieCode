using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;

namespace BowieCode {

    public partial class EditorUtils {

        /// <summary>
        /// Helps to draw a reorderable list with the correct spacing.
        /// </summary>
        /// <param name="list"></param>
        public static void DrawReorderableList ( ReorderableList list ) {
            GUILayout.Space( 5 );
            try {
                list.DoLayoutList();
            } catch ( Exception e ) {
                Debug.Log( "Failed to draw list. Is the list template class [System.Serializable]?" );
                throw e;
            }
            GUILayout.Space( 5 );
        }

        /// <summary>
        /// Helper to set up a reorderable list.
        /// </summary>
        /// <param name="serializedObject">serializedObject</param>
        /// <param name="listTitle">Display name</param>
        /// <param name="property">The name of the List in the serializedObject</param>
        /// <param name="subproperties">A list of the Lists propreties to display</param>
        /// <returns></returns>
        public static ReorderableList CreateReorderableList ( SerializedObject serializedObject, string listTitle, string property, string[] subproperties ) {
            var list = new ReorderableList( serializedObject,
                    serializedObject.FindProperty( property ),
                    true, true, true, true );

            list.drawElementCallback = ( Rect rect, int index, bool isActive, bool isFocused ) => {
                var element = list.serializedProperty.GetArrayElementAtIndex( index );

                rect.height = EditorGUIUtility.singleLineHeight;

                for ( int idx = 0; idx < subproperties.Length; ++idx ) {
                    EditorGUI.PropertyField( rect, element.FindPropertyRelative( subproperties[ idx ] ) );
                    rect.y += EditorGUIUtility.singleLineHeight + 3;
                }
            };

            list.elementHeightCallback = ( int index ) => {
                return ( EditorGUIUtility.singleLineHeight + 3 ) * subproperties.Length;
            };

            list.drawHeaderCallback = ( Rect rect ) => {
                EditorGUI.LabelField( rect, listTitle );
            };

            return list;
        }
    }
}

#endif