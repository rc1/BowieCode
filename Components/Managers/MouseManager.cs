using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BowieCode;

/// <summary>
/// Hide the mouse after a set time of activity or if the mouse is not connected
/// </summary>
public class MouseManager : MonoBehaviour {

    public bool hideMouse = true;
    public float afterSeconds = 10f;
    
    private Vector3 _lastMousePosition;
    private float _lastMouseMoveTime = 0;


    void Awake () {
        DefaultInstance<MouseManager>.Set( this );
        
        // Hide the mouse if it does not exist
        if ( !Input.mousePresent ) {
            Cursor.visible = false;
        }

    }

    void Update () {
        
        if ( !BowieMath.CompareVectors( _lastMousePosition, Input.mousePosition ) ) {
            _lastMouseMoveTime = Time.fixedTime;
        }

        _lastMousePosition = Input.mousePosition;

        Cursor.visible = (Time.fixedTime - _lastMouseMoveTime < afterSeconds);

    }

}