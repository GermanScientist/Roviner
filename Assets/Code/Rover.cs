using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rover : MonoBehaviour {
    private int minerals = 0;
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

    private float acceleration = 2000;
    public float Acceleration {
        set { acceleration = value; }
    }

    private float breakforce = 1700;
    private float maxTurnAngle = 30f;

    private float currentAcceleration = 0f;
    private float currentBrakeforce = 0f;
    private float currentTurnAngle = 0f;

    [SerializeField] private Joystick joystick;
    [SerializeField] private EventTrigger mineButton;

    private Coroutine lastCoroutine;

    private void Start() {
        mineButton.enabled = false;
    }

    private void FixedUpdate() {
        // Get forward and reverse from the joystick input
        currentAcceleration = acceleration * joystick.CalculateYInput();

        // Get left and right from the joystick input
        currentTurnAngle = maxTurnAngle * joystick.CalculateXInput();

        // Apply acceleration force to the front wheels
        frontLeft.motorTorque = -currentAcceleration;
        frontRight.motorTorque = -currentAcceleration;

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
        //backLeft.brakeTorque = currentBrakeforce;
        //backRight.brakeTorque = currentBrakeforce;

        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;
    }

    public void StartMining() {
        Debug.Log("Mining minerals");
        // play animation
        // wait for animation to be over
        lastCoroutine = StartCoroutine(MineMinerals());
    }

    public void StopMining() {
        StopCoroutine(lastCoroutine);
    }

    private IEnumerator MineMinerals() {
        while (!Input.GetMouseButtonUp(0)) {
            minerals += 1;
            Debug.Log(minerals);
            yield return new WaitForSeconds(1);
        }
    }


    public void DisableMining() {
        mineButton.enabled = false;
    }

    public void EnableMining() {
        mineButton.enabled = true;
    }
}
