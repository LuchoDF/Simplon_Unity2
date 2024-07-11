using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInput : MonoBehaviour{
    private Camera mainCamera;
    private Rigidbody2D rb;

    void Start() {
        mainCamera = Camera.main;
        // Récupère le Rigidbody2D de la balle
        rb = GetComponent<Rigidbody2D>();

    }

    void Update() {

        if (!Touchscreen.current.primaryTouch.press.IsPressed()) {
            return;
        }

        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

        rb.MovePosition(new Vector2(worldPosition.x, worldPosition.y));

        Debug.Log("TOUCH POSITION: " + touchPosition);
        Debug.Log("WORLD POSITION: " + worldPosition);


    }
}