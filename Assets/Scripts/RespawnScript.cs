using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour {
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider other) {
        other.transform.position = respawnPoint.position;
        Rigidbody otherRb = other.GetComponent<Rigidbody>();
        otherRb.velocity = new Vector3(0, 0, 0);
    }

}
