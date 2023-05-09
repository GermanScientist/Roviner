using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private float camX;
    private float camY;

    public void DragCamera() {
        Debug.Log("dragging camera");
        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * 1, -Input.GetAxis("Mouse X") * 1, 0));
        camX = transform.rotation.eulerAngles.x;
        camY = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(camX, camY, 0);
    }
}
