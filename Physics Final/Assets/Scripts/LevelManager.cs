using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    private static PlayerController player;

    private static Vector2 lastCheckpoint;
    private static int checkpointsHit = 0;
    private static float timer = 0;

    private static float countdownTimer = 0;
    private static bool isCountingDown = true;
    private static int countDownState = 1;
    private const float COUNTDOWN_TIME = 2.5f;

	private bool showCountdown = false;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.IsFrozen = true;

        lastCheckpoint = player.gameObject.transform.position;

		Invoke("countDownLabel", 3);
    }

	public void countDownLabel()
	{
		showCountdown = !showCountdown;

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

    public void OnGUI()
    {
        GUI.Label(new Rect(10,10, 200,50), new GUIContent("Your Time: "+ timer));

		if(!showCountdown)
		{
			if(countDownState == 0)
			{
				GUI.Label(new Rect(Screen.width * 0.5f - 100f, Screen.height * 0.5f - 200f, 100f, 50f),"GO!");
			}

			else
			{
				GUI.Label(new Rect(Screen.width * 0.5f - 100f, Screen.height * 0.5f - 200f, 100f, 50f),"Countown: " + countDownState);
			}
		}
	}

}
