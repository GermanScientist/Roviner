using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rover : MonoBehaviour {
    private int minerals;
    private int health;
    private int energy;

    // Wheel colliders from the rover
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider backLeft;
    [SerializeField] private WheelCollider backRight;

    private float acceleration = 150f;
    private float breakforce = 100f;
    private float maxTurnAngle = 10f;

    private float currentAcceleration = 0f;
    private float currentBreakforce = 0f;
    private float currentTurnAngle = 0f;

    private void FixedUpdate() {
        // Get forward and reverse from the W and S keys
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        // Get left and right input from the A and D keys
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");

        // Check if player is hitting the brake
        if (Input.GetKey(KeyCode.Space)) {
            currentBreakforce = breakforce;
        } else {
            currentBreakforce = 0f;
        }

        // Apply acceleration force to the front wheels
        frontLeft.motorTorque = currentAcceleration;
        frontRight.motorTorque = currentAcceleration;

        // Apply breaks
        frontLeft.brakeTorque = currentBreakforce;
        frontRight.brakeTorque = currentBreakforce;
        backLeft.brakeTorque = currentBreakforce;
        backRight.brakeTorque = currentBreakforce;

        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;
    }
}
