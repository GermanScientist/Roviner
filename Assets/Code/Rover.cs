using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rover : MonoBehaviour {
    private int minerals;
    public int Minerals {
        get { return minerals; }
        set { minerals = value; }
    }

    private int health;
    public int Health {
        get { return health; }
        set { health = value; }
    }

    private int energy;
    public int Energy {
        get { return energy; }
        set { energy = value; }
    }

    private int currency;
    public int Currency {
        get { return currency; }
        set { currency = value; }
    }

    // Wheel colliders from the rover
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider backLeft;
    [SerializeField] private WheelCollider backRight;

    private float acceleration = 150f;
    public float Acceleration {
        set { acceleration = value; }
    }

    private float breakforce = 100f;
    private float maxTurnAngle = 10f;

    private float currentAcceleration = 0f;
    private float currentBreakforce = 0f;
    private float currentTurnAngle = 0f;

    private Joystick joystick;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            SearchForMinerals();
        }
    }

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

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Mineral") {
            Debug.Log("In mining range");
        }
    }

    private void SearchForMinerals() {

    }

    private void MineMinerals() {

    }
}
