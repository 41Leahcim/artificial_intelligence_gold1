using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour{
    // The movement and rotation speed of the camera
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    // The movement and rotation input of the player
    private Vector3 movement = Vector3.zero;
    private float rotation = 0;

    void Update(){
        // Move and rotate the camera based on user input
        transform.Translate(movement * movementSpeed * Time.deltaTime);
        transform.Rotate(rotation * rotationSpeed * Time.deltaTime * Vector3.up);
    }

    // React on movement and rotation input changes, and when the exit button is pressed
    void OnMovement(InputValue value) => movement = value.Get<Vector3>();
    void OnRotation(InputValue value) => rotation = value.Get<float>();
    void OnExit(InputValue value) => Application.Quit(0);
}
