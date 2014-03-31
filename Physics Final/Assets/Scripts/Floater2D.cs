using UnityEngine;
using System.Collections;

public class Floater2D : MonoBehaviour {
	public float waterLevel, floatHeight;
	public Vector3 buoyancyCentreOffset;
	public float bounceDamp;
	
	
	
	void FixedUpdate () {
		Vector3 actionPoint = rigidbody2D.transform.position + rigidbody2D.transform.TransformDirection(buoyancyCentreOffset);
		float forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);
		
		if (forceFactor > 0f) {
			Vector3 uplift = -Physics2D.gravity * (forceFactor - rigidbody2D.velocity.y * bounceDamp);
			rigidbody2D.AddForceAtPosition(uplift, actionPoint);
		}
	}
}
