using UnityEditor;
using UnityEditorInternal;
using BowieCode;

[CustomEditor( typeof( ReorderableListExample ) )]
public class ReorderableListExampleEditor : Editor {

	private ReorderableList list;

	private void OnEnable () {
		list = ReorderableListUtil.Create( serializedObject, "My List", "dataList", new string[] { "name", "toggle" } );
	}

	public override void OnInspectorGUI () {
		ReorderableListExample reorderableListExample = (ReorderableListExample)target;

		serializedObject.Update();

		DrawDefaultInspector();

		if ( reorderableListExample.showList ) {
			ReorderableListUtil.Draw( list );
		}

		serializedObject.ApplyModifiedProperties();
	}
}