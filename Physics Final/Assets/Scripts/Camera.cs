using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public GameObject target;
    public bool followTarget;

	void Start () {
	
	}
	
	void Update () {
        Vector2 newPos = Vector3.Slerp(transform.position, target.transform.position, 1);
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
	}
}
