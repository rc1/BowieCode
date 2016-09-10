using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using BowieCode;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor( typeof( ReorderableListExample ) )]
public class ReorderableListExampleEditor : Editor {

    private ReorderableList list;

    private void OnEnable () {
        list = EditorUtils.CreateReorderableList( serializedObject, "My List", "dataList", new string[] { "name", "toggle" } );
    }

    public override void OnInspectorGUI () {
        ReorderableListExample reorderableListExample = (ReorderableListExample)target;

        serializedObject.Update();

        DrawDefaultInspector();

        if ( reorderableListExample.showList ) {
            EditorUtils.DrawReorderableList( list );
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif

namespace BowieCode {

    public class ReorderableListExample : MonoBehaviour {

        [System.Serializable]
        public class MyDataClass {
            public string name = "";
            public bool toggle = true;
        }

        [HideInInspector]
        public List<MyDataClass> dataList = new List<MyDataClass> ();

        public bool showList = true;
 
    }

}
