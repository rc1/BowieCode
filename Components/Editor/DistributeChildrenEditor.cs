using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BowieCode {

	[CustomEditor(typeof(DistributeChildren))]
	public class DistributeChildrenEditor : Editor {
		
		void OnSceneGUI () {

			var distributeChildren = target as DistributeChildren;

			Vector3 oldA = distributeChildren.a;
			Vector3 oldB = distributeChildren.b;

			Vector3 newA = Handles.PositionHandle( oldA + distributeChildren.transform.position, Quaternion.Euler( distributeChildren.transform.up ) ) - distributeChildren.transform.position;
			Vector3 newB = Handles.PositionHandle( oldB + distributeChildren.transform.position, Quaternion.Euler( distributeChildren.transform.up ) ) - distributeChildren.transform.position;

			if ( oldA != newA || newB != oldB ) {
				distributeChildren.a = newA;
				distributeChildren.b = newB;
				distributeChildren.RedistributeChildren();
			}

		}

	}

}
