using System;
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

    public event Action OnMouseShow;
    public event Action OnMouseHide;
    
    private enum MouseState {
        NotSet,
        Visible,
        Invisible
    }
    private MouseState _lastMouseState = MouseState.NotSet;

    void Awake () {
        DefaultInstance<MouseManager>.Set( this );
    }

    void Start() {
        // Hide the mouse if it does not exist
        if ( !Input.mousePresent ) {
            SetMouseVisibleState( false );
        }
    }

    void Update () {

        if ( !Input.mousePresent ) {
            return;
        }
        
        if ( !BowieMath.CompareVectors( _lastMousePosition, Input.mousePosition ) ) {
            _lastMouseMoveTime = Time.fixedTime;
        }

        _lastMousePosition = Input.mousePosition;

        SetMouseVisibleState( Time.fixedTime - _lastMouseMoveTime < afterSeconds );

    }

    private void SetMouseVisibleState ( bool shouldBeVisible ) {

        var newMouseState = shouldBeVisible ? MouseState.Visible : MouseState.Invisible;

        Cursor.visible = shouldBeVisible;
       
        // Raise the event if there were a change
        if ( newMouseState != _lastMouseState ) {
            if ( shouldBeVisible && OnMouseShow != null ) {
                OnMouseShow();
            }
            else if ( !shouldBeVisible && OnMouseHide != null ) {
                OnMouseHide();
            }
        }
        
        _lastMouseState = newMouseState;
        
    }

}