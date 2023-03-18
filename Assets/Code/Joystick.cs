using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour {
    [SerializeField] private GameObject joystickBg;
    private float maxJoystickDragDis = 100;
    private float joystickDragDis;
    private float joystickDis;
    public float JoystickDis {
        get { return joystickDis; }
    }

    public void DragJoystick() {
        transform.position = Input.mousePosition;
        joystickDragDis = Vector2.Distance(Input.mousePosition, joystickBg.transform.position);

        if (joystickDragDis > maxJoystickDragDis) {
            transform.position = joystickBg.transform.position + (Input.mousePosition - joystickBg.transform.position).normalized * maxJoystickDragDis;
        } else {
            transform.position = Input.mousePosition;
        }

        joystickDis = Vector2.Distance(transform.position, joystickBg.transform.position);
        Debug.Log(joystickDis / 100);
    }

    public void LetGoOfJoystick() {
        transform.position = joystickBg.transform.position;
    }

    public float CalculateXInput() {
        float input = 0;
        input = (joystickBg.transform.position.x - transform.position.x) / -100;
        return input;
    }

    public float CalculateYInput() {
        float input = 0;
        input = (joystickBg.transform.position.y - transform.position.y) / -100;
        Debug.Log($"input: {input}");
        return input;
    }
}
