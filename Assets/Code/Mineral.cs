using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineral : MonoBehaviour {
    [SerializeField] private Rover rover;

    private void OnTriggerEnter(Collider collision) {
        rover.EnableMining(this.gameObject);
    }

    private void OnTriggerExit(Collider collision) {
        rover.DisableMining();
    }
}
