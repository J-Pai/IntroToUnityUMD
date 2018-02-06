using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;

    private Vector3 offset;

    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate () {
        if (Input.GetAxis("Vertical") >= 0) {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, player.transform.eulerAngles.y, 0.0f);

            float rbAngle = transform.eulerAngles.y * Mathf.Deg2Rad;
            float xPos = 0;
            float zPos = 0;

            // Do some calculations to obtain correct directional velocities
            if (rbAngle >= 0 && rbAngle < Mathf.PI / 2) {
                xPos = offset.z * Mathf.Sin(rbAngle);
                zPos = offset.z * Mathf.Cos(rbAngle);
            } else if (rbAngle >= Mathf.PI / 2 && rbAngle < Mathf.PI) {
                rbAngle = rbAngle - Mathf.PI / 2;
                xPos = offset.z * Mathf.Cos(rbAngle);
                zPos = offset.z * -1 * Mathf.Sin(rbAngle);
            } else if (rbAngle >= Mathf.PI && rbAngle < 3 * Mathf.PI / 2) {
                rbAngle = rbAngle - Mathf.PI;
                xPos = offset.z * -1 * Mathf.Sin(rbAngle);
                zPos = offset.z * -1 * Mathf.Cos(rbAngle);
            } else {
                rbAngle = rbAngle - 3 * Mathf.PI / 2;
                xPos = offset.z * -1 * Mathf.Cos(rbAngle);
                zPos = offset.z * Mathf.Sin(rbAngle);
            }


            transform.position = new Vector3(xPos, offset.y, zPos) + player.transform.position;
        } else {
            transform.position = player.transform.position + offset;
        }
    }
}
