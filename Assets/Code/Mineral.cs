using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineral : MonoBehaviour {
    [SerializeField] private Rover rover;

    private void OnTriggerEnter(Collider collision) {
        rover.EnableMining();
    }

    private void OnTriggerExit(Collider collision) {
        rover.DisableMining();
    }

    private void GetDistanceFromPlayer() {

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2);
    }
}
