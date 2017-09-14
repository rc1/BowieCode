using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BowieCode;

/// <summary>
/// App Manager features:
/// - can hide the mouse automatically,
/// - can set the app to run in the backgroud
/// </summary>
public class AppManager : MonoBehaviour {

    [Header( "App" )]
    [SerializeField]
    [DisableOnPlay]
    private bool _runInBackground = false;
    
    [Header("Mouse")]
    [SerializeField]
    [DisableOnPlay]
    private bool _hidesMouse = true;
    [SerializeField]
    [DisableOnPlay]
    private float _afterSeconds = 10f;
    
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
        Application.runInBackground = _runInBackground;
        DefaultInstance<AppManager>.Set( this );
    }

    void Start() {
        // Hide the mouse if it does not exist
        if ( !Input.mousePresent && _hidesMouse ) {
            SetMouseVisibleState( false );
        }
    }

    void Update () {
        
       
        if ( !Input.mousePresent || !_hidesMouse ) {
            return;
        }
        
        if ( !BowieMath.CompareVectors( _lastMousePosition, Input.mousePosition ) ) {
            _lastMouseMoveTime = Time.fixedTime;
        }

        _lastMousePosition = Input.mousePosition;

        SetMouseVisibleState( Time.fixedTime - _lastMouseMoveTime < _afterSeconds );

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