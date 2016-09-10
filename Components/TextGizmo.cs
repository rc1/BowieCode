using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BowieCode {

    /// <summary>
    /// Displays the gameobject's name or other text in the Scene View
    /// </summary>
    public class TextGizmo : MonoBehaviour {

        public bool useGameObjectName = true;
        public string text = "";

#if UNITY_EDITOR
        public virtual void OnDrawGizmos () {
            Handles.Label( transform.position, useGameObjectName ? transform.gameObject.name : text );
        }
#endif
    }

}
