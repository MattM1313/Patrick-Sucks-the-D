﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public bool isPaused = true;

    public float torqueForce;
    public GameObject wheel;
    public bool touchingWheel;

    private const int FLIP_DELAY = 2;
    private bool canFlip = true;

	void Start () {
	}

    void Update() {
        if (!isPaused) {
            if (touchingWheel) {
                if (Input.GetAxis("Horizontal") != 0) {
                    wheel.rigidbody2D.AddTorque(torqueForce * -Input.GetAxis("Horizontal"));
                }
            }
            else {
                if (Input.GetKeyDown(KeyCode.UpArrow) && canFlip) {
                    StartCoroutine(FlipOver());
                }
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                LevelManager.ResetToCheckpoint();
            }
        }
    }

    IEnumerator FlipOver() {
        canFlip = false;

        Vector2 flipForce = new Vector2(1, -1) * rigidbody2D.mass * 100;
        rigidbody2D.AddForceAtPosition(transform.TransformDirection(flipForce), transform.TransformPoint(Vector2.right));

        yield return new WaitForSeconds(FLIP_DELAY);
        canFlip = true;
    }

    public void ResetToPosition(Vector2 pos) {
        transform.parent.position = new Vector3(pos.x, pos.y, transform.parent.position.z);
        transform.position = new Vector3(pos.x, pos.y, transform.localPosition.z);
        wheel.transform.position = new Vector3(pos.x, pos.y, wheel.transform.localPosition.z);

        transform.parent.rotation = Quaternion.identity;
        transform.rotation = Quaternion.identity;
        wheel.transform.rotation = Quaternion.identity;

        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.angularVelocity = 0;
        wheel.rigidbody2D.velocity = Vector2.zero;
        wheel.rigidbody2D.angularVelocity = 0;
    }

}
