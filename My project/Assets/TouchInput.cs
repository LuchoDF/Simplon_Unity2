using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInput : MonoBehaviour{
    private Camera mainCamera;
    private Rigidbody2D rb;
    public Rigidbody2D ballRigidbody;
    public SpringJoint2D ballSpringJoint;
    private bool isDragging = false;
    public float detachDelay = 0.2f;
    public float respawnDelay = 5f;
    public GameObject ballPrefab;
    public GameObject currentBall;
    public Vector3 respawnPosition;

    void Start() {
        mainCamera = Camera.main;
        // SpawnBall();
    }

    void Update() {

        if (!Touchscreen.current.primaryTouch.press.IsPressed())
        {   
            if(isDragging)
            {
                LaunchBall();
                // Invoke(nameof(SpawnBall),respawnDelay);
                isDragging = false;
            }
            return;
        }

        isDragging = true;

        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
        ballRigidbody.isKinematic = true;
        ballRigidbody.position = worldPosition;

        Debug.Log("TOUCH POSITION: " + touchPosition);
        Debug.Log("WORLD POSITION: " + worldPosition);

    }

    private void SpawnBall(){

        if(ballPrefab != null){
            if(currentBall != null){
                Destroy(currentBall);
            }

            GameObject newBall = Instantiate(ballPrefab, respawnPosition, Quaternion.identity);
            ballRigidbody = newBall.GetComponent<Rigidbody2D>();
            ballSpringJoint = newBall.GetComponent<SpringJoint2D>();

        
            GameObject pivot = GameObject.Find("Pivot");
            if (pivot != null)
            {
                ballSpringJoint.connectedBody = pivot.GetComponent<Rigidbody2D>();
            }

        }

    }
    private void LaunchBall(){
        if (ballRigidbody != null){
            ballRigidbody.isKinematic = false;
            ballRigidbody = null;
            Invoke(nameof(DetachBall), detachDelay);

        }
    }

    private void DetachBall(){
        if(ballSpringJoint != null){
            ballSpringJoint.enabled = false;
            ballSpringJoint = null;
        }
    }
}