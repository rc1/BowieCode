using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BowieCode {

	[CustomEditor(typeof(DistributeChildren))]
	public class DistributeChildrenEditor : Editor {
		
		void OnSceneGUI () {

			var distributeChildren = target as DistributeChildren;

			bool isDirty = false;

			if ( distributeChildren.point1enabled ) {
				Vector3 oldA = distributeChildren.point1;
				Vector3 newA = Handles.PositionHandle( oldA + distributeChildren.transform.position, Quaternion.Euler( distributeChildren.transform.up ) ) - distributeChildren.transform.position;
				if ( oldA != newA ) {
					isDirty = true;
					distributeChildren.point1 = newA;
				}
			}

			if ( distributeChildren.point2enabled ) {
				Vector3 oldB = distributeChildren.point2;
				Vector3 newB = Handles.PositionHandle( oldB + distributeChildren.transform.position, Quaternion.Euler( distributeChildren.transform.up ) ) - distributeChildren.transform.position;
				if ( oldB != newB ) {
					isDirty = true;
					distributeChildren.point2 = newB;
				}
			}

			if ( isDirty ) {
				Undo.RecordObject( target, "Move distribution points" );
				distributeChildren.RedistributeChildren();
			}

		}

	}

}
