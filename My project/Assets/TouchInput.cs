using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInput : MonoBehaviour{
    private Camera mainCamera;

    void Start() {
        mainCamera = Camera.main;
    }

    void Update() {

        if (!Touchscreen.current.primaryTouch.press.IsPressed()) {
            return;
        }

        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

        Debug.Log("TOUCH POSITION: " + touchPosition);
        Debug.Log("WORLD POSITION: " + worldPosition);


    }
}