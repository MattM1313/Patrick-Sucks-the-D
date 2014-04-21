using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    public bool followTarget;
    public float cameraDist = 10;

    void Start() {
        if (followTarget) {
            transform.localPosition = new Vector3(target.transform.localPosition.x, target.transform.localPosition.y, -cameraDist);
        }
    }

	void Update () {
        if (followTarget) {
            //transform.localPosition = Vector3.Slerp(transform.localPosition, new Vector3(target.transform.localPosition.x, target.transform.localPosition.y, -cameraDist), Time.deltaTime);

            transform.localPosition = new Vector3(target.transform.localPosition.x, target.transform.localPosition.y, -cameraDist);
        }
	}
}
