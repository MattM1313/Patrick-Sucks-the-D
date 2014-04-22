using UnityEngine;
using System.Collections;

public class BridgeLinkCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "HamsterWheel")
		{
			AudioManager.me.PlayClip(1, AudioChannel.SoundEffects);
		}
	}
}
