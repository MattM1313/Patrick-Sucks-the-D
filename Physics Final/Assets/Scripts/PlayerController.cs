using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float torqueForce;
    public GameObject wheel;
    public bool touchingWheel;

    private const int FLIP_DELAY = 2;
    private bool canFlip = true;

	void Start () {
	
	}

    void Update() {
        if (touchingWheel) {
            if (Input.GetAxis("Horizontal") != 0) {
                wheel.rigidbody2D.AddTorque(torqueForce * -Input.GetAxis("Horizontal"));
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                StartCoroutine(FlipOver());
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

}
