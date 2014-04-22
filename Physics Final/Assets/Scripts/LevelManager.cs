using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {
	public GUIStyle guiStyle;

	private static PlayerController player;

	private static Vector2 lastCheckpoint;
	private static int checkpointsHit = 0;
	private static float timer = 0;

	private static float countdownTimer = 0;
	private static bool isCountingDown = true;
	private static int countDownState = 0;

	private const float COUNTDOWN_TIME = 2.5f;

	private bool showCountdown = true;

    public AudioClip audioCountdown, audioGo;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		player.IsFrozen = true;

		lastCheckpoint = player.gameObject.transform.position;

		Invoke("countDownLabel", 3);
	}

	public void countDownLabel()
	{
        showCountdown = false;

	}

	void Update() {
		if (isCountingDown) {
			countdownTimer += Time.deltaTime;

            if (countdownTimer == Time.deltaTime) {
                audio.PlayOneShot(audioCountdown);
            }
			if (countdownTimer >= COUNTDOWN_TIME / 3 * (countDownState + 1)) {
                if (countdownTimer >= COUNTDOWN_TIME) {
                    isCountingDown = false;
                    countdownTimer = 0;
                    countDownState = 0;
                    player.IsFrozen = false;
                    player.IsControllable = true;

                    audio.PlayOneShot(audioGo);
                }
                else {
                    ++countDownState;
                    audio.PlayOneShot(audioCountdown);
                }
			}
			
		}
		else {
            if (!player.IsFrozen) {
                timer += Time.deltaTime;
            }
		}
	}
	

	public static void ReachCheckpoint(Vector2 checkpoint) {
		lastCheckpoint = checkpoint;
		++checkpointsHit;
	}

	public static void FinishLevel() {
		++checkpointsHit;
		player.IsControllable = false;
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
		if(showCountdown)
		{
			if(!isCountingDown)
			{
				GUI.Label(new Rect(Screen.width * 0.55f - 100f, Screen.height * 0.5f - 200f, 100f, 50f), "GO!", guiStyle);
			}

			else
			{
				GUI.Label(new Rect(Screen.width * 0.55f - 100f, Screen.height * 0.5f - 200f, 100f, 50f), "" + (countDownState + 1), guiStyle);
			}
		}
		else
		{
			GUI.Label(new Rect(10, 10, 200, 50), new GUIContent("Your Time: " + timer.ToString("0.00")), guiStyle);
		}
	}

}
