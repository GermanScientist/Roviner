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
    private float currentBrakeforce = 0f;
    private float currentTurnAngle = 0f;

    [SerializeField] private Joystick joystick;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            SearchForMinerals();
        }
    }

    private void FixedUpdate() {
        // Get forward and reverse from the joystick input
        currentAcceleration = acceleration * joystick.CalculateYInput();

        // Get left and right from the joystick input
        currentTurnAngle = maxTurnAngle * joystick.CalculateXInput();

        // Check if player is hitting the brake
        /*if (Input.GetKey(KeyCode.Space)) {
            currentBrakeforce = breakforce;
        } else {
            currentBrakeforce = 0f;
        }*/

        // Apply acceleration force to the front wheels
        frontLeft.motorTorque = currentAcceleration;
        frontRight.motorTorque = currentAcceleration;

        ApplyBrakes();
    }

    public void BrakesPressed() {
        currentBrakeforce = breakforce;
    }

    public void BrakesLetGo() {
        currentBrakeforce = 0f;
    }

    private void ApplyBrakes() {
        // Apply breaks
        frontLeft.brakeTorque = currentBrakeforce;
        frontRight.brakeTorque = currentBrakeforce;
        backLeft.brakeTorque = currentBrakeforce;
        backRight.brakeTorque = currentBrakeforce;

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
