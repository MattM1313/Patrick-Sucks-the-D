using UnityEngine;
using System.Collections;

public class PlayerFeet : MonoBehaviour {

    public CircleCollider2D innerWheel;
    public PlayerController player;

    void OnTriggerEnter2D(Collider2D col) {
        if (col == innerWheel) {
            player.touchingWheel = false;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col == innerWheel) {
            player.touchingWheel = true;
        }
    }

}
