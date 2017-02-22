using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A datatype to help define where GameObject(s) should be placed. But does give a 
/// handle dropbox menu in the Editor which displays the target gameobject 
/// property when required
/// </summary>
[System.Serializable]
public class ParentingMode  {

	public enum ModeType {
		Target,
		Self,
		Scene
	}

	/// <summary>
	/// How the GameObject(s) should be placed
	/// </summary>
	public ModeType mode;

	/// <summary>
	/// The target when ModeType.target
	/// </summary>
	public Transform target;

	/// <summary>
	/// Preforms the parenting.
	/// </summary>
	/// <param name="self">Own is the self transform, used when ModeType.Self</param>
	/// <param name="child">The transform to be parented.</param>
	public void DoParent( Transform self, Transform child ) {
		switch ( mode ) {
			case ModeType.Self:
				child.parent = self;
				break;
			case ModeType.Target:
				child.parent = target;
				break;
			case ModeType.Scene:
				child.parent = child.root;
				break;
			default:
				break;
		}
	}
	  
}
