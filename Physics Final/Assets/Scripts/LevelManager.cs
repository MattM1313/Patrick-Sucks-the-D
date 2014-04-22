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

	private static bool isMusicPlaying = false;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		player.IsFrozen = true;

		lastCheckpoint = player.gameObject.transform.position;

		Invoke("countDownLabel", 3);


        /// Reset the static values
        checkpointsHit = 0;
        timer = 0;

        countdownTimer = 0;
        isCountingDown = true;
        countDownState = 0;

        bool showCountdown = true;


		if (!isMusicPlaying)
		{
			AudioManager.me.PlayClip(3, AudioChannel.Music);
			isMusicPlaying = true;
		}
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

		timer += Time.deltaTime;
   
		Debug.Log("Level finished in " + timer);

		++GameManager.Level;

		if ((GameManager.Level) > 5)
		{
			GameManager.ChangeState = GameManager.GameStates.LEVELSELECT;
			GameManager.musicPlaying = false;
			Application.LoadLevel("Main Menu");
		}
		else
		{
			GameManager.ChangeState = GameManager.GameStates.LOADNEXTLEVEL;
			Application.LoadLevel("Main Menu");
			//Application.LoadLevel("Level" + (GameManager.Level));
		}
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
