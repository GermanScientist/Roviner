using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    private float acceleration = 5000;
    public float Acceleration {
        set { acceleration = value; }
    }

    private float breakforce = 2000;
    private float maxTurnAngle = 30f;

    private float currentAcceleration = 0f;
    private float currentBrakeforce = 0f;
    private float currentTurnAngle = 0f;

    [SerializeField] private Joystick joystick;
    [SerializeField] private EventTrigger mineButton;
    [SerializeField] private GameObject minerRotationPoint;
    private GameObject mineral;

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
        mineButton.GetComponent<Image>().color = new Color32(150, 150, 150, 255);
        // play animation
        // wait for animation to be over
        lastCoroutine = StartCoroutine(MineMinerals());
    }

    public void StopMining() {
        mineButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        StopCoroutine(lastCoroutine);
    }

    private IEnumerator MineMinerals() {
        while (!Input.GetMouseButtonUp(0)) {
            ApplyBrakes();

            //find the vector pointing from our position to the target
            //Vector3 target = mineral.transform.position;

            //create the rotation we need to be in to look at the target
            /*Quaternion targetRotation = 
            Debug.Log($"target rotation is {targetRotation.y}");
            Debug.Log($"current rotation is {minerRotationPoint.transform.rotation}");

            targetRotation.x = 0;
            targetRotation.z = 0;
            //rotate us over time according to speed until we are in the required rotation
            minerRotationPoint.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5);
            */

            /*if (minerRotationPoint.transform.rotation != targetRotation)
                yield return null;*/
            yield return new WaitForSeconds(10);
            minerals += 1;
            Debug.Log(minerals);
        }
    }

    public void DisableMining() {
        mineButton.enabled = false;
    }

    public void EnableMining(GameObject m) {
        mineButton.enabled = true;
        mineral = m;
    }
}
