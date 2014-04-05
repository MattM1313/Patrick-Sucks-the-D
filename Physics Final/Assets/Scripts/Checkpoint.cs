using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]

public class Checkpoint : MonoBehaviour {

    public enum CheckpointType {
        CONTINUE,
        FINISH
    }

    public CheckpointType type;
    public Transform playerSpawn;

    void Start() {
        collider2D.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.tag == "Player") {
            if (type == CheckpointType.CONTINUE) {
                LevelManager.ReachCheckpoint(playerSpawn.position);
            }

            if (type == CheckpointType.FINISH) {
                LevelManager.FinishLevel();
            }
        }
    }

}
