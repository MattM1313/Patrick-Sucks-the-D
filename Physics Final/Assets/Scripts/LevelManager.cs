using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    private static PlayerController player;

    private static Vector2 lastCheckpoint;
    private static int checkpointsHit = 0;
    private static float timer = 0;

    private static float countdownTimer = 0;
    private static bool isCountingDown = true;
    private static int countDownState = 0;
    private const float COUNTDOWN_TIME = 2.5f;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.IsFrozen = true;

        lastCheckpoint = player.gameObject.transform.position;
    }

    void Update() {
        if (isCountingDown) {
            countdownTimer += Time.deltaTime;

            if (countdownTimer >= COUNTDOWN_TIME / 4 * (countDownState + 1)) {
                ++countDownState;
                Debug.Log("Countown: " + countDownState);
            }
            if (countdownTimer >= COUNTDOWN_TIME) {
                isCountingDown = false;
                countdownTimer = 0;
                countDownState = 0;
                player.IsFrozen = false;
                player.IsControllable = true;
                Debug.Log("GO");
            }
        }
        else {
            timer += Time.deltaTime;
        }
    }
    

    public static void ReachCheckpoint(Vector2 checkpoint) {
        lastCheckpoint = checkpoint;
        ++checkpointsHit;
    }

    public static void FinishLevel() {
        ++checkpointsHit;
        player.IsControllable = true;
        Debug.Log("Level finished in " + timer);
    }

    public static void ResetToCheckpoint() {
        if (checkpointsHit > 0) {
            player.ResetToPosition(lastCheckpoint);
        }
        else {
            // reset everything basically
            // but for now
            player.ResetToPosition(lastCheckpoint);
        }
    }

}
