using UnityEditor;
using UnityEngine;

namespace BowieCode {

    /// <summary>
    /// Apply or revert multiple prefabs at the same time
    /// Adapted from https://forum.unity3d.com/threads/little-script-apply-and-revert-several-prefab-at-once.295311/
    /// </summary>
    public class Prefabs {
        
        private delegate void ChangePrefab ( GameObject go );

        private const int SelectionThresholdForProgressBar = 20;

        [MenuItem( "BowieCode/Prefabs/Apply Changes To Selected", false, 100 )]
        private static void ApplyChangesToSelectedPrefabs () {
            SearchPrefabConnections( ApplyToSelectedPrefabs );
        }

        [MenuItem( "BowieCode/Prefabs/Revert Changes Of Selected", false, 100 )]
        private static void ResetChangesToSelectedPrefabs () {
            SearchPrefabConnections( RevertToSelectedPrefabs );
        }

        [MenuItem( "BowieCode/Prefabs/Apply Changes To Selected", true )]
        [MenuItem( "BowieCode/Prefabs/Revert Changes Of Selected", true )]
        private static bool IsSceneObjectSelected () {
            return Selection.activeTransform != null;
        }

        private static void SearchPrefabConnections ( ChangePrefab changePrefabAction ) {
            GameObject[] selectedTransforms = Selection.gameObjects;
            int numberOfTransforms = selectedTransforms.Length;
            bool showProgressBar = numberOfTransforms >= SelectionThresholdForProgressBar;
            int changedObjectsCount = 0;
            //Iterate through all the selected gameobjects
            try {
                for ( int i = 0; i < numberOfTransforms; i++ ) {
                    if ( showProgressBar ) {
                        EditorUtility.DisplayProgressBar( "Update prefabs",
                                                          "Updating prefabs (" + i + "/" + numberOfTransforms + ")",
                                                          (float) i / (float) numberOfTransforms );
                    }

                    var go = selectedTransforms[ i ];
                    var prefabType = PrefabUtility.GetPrefabType( go );
                    //Is the selected gameobject a prefab?
                    if ( prefabType == PrefabType.PrefabInstance ||
                         prefabType == PrefabType.DisconnectedPrefabInstance ) {
                        var prefabRoot = PrefabUtility.FindRootGameObjectWithSameParentPrefab( go );
                        if ( prefabRoot == null ) {
                            continue;
                        }

                        changePrefabAction( prefabRoot );
                        changedObjectsCount++;
                    }
                }
            }
            finally {
                if ( showProgressBar ) {
                    EditorUtility.ClearProgressBar();
                }
                Debug.LogFormat( "{0} Prefab(s) updated", changedObjectsCount );
            }
        }

        private static void ApplyToSelectedPrefabs ( GameObject go ) {
            var prefabAsset = PrefabUtility.GetPrefabParent( go );
            if ( prefabAsset == null ) {
                return;
            }

            PrefabUtility.ReplacePrefab( go, prefabAsset, ReplacePrefabOptions.ConnectToPrefab );
        }

        private static void RevertToSelectedPrefabs ( GameObject go ) {
            PrefabUtility.ReconnectToLastPrefab( go );
            PrefabUtility.RevertPrefabInstance( go );
        }
    }
}