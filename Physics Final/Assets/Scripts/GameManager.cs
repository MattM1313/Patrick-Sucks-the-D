using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static bool _created;
	// gameState Option should display a different version of Playstate Options

	public Texture[] buttons;

	public enum ButtonTextureID {
		ACCEPT,
		BACK,
		NO,
		OPTIONS,
		QUIT,
		RESUME,
		RETURN,
		START,
		YES,
	}

	public enum GameStates {TITLE, PLAY, LEVELSELECT, LOADNEXTLEVEL, PAUSE, OPTIONS, EXIT};
	private static GameStates gameState = GameStates.TITLE;

	public int selGridInt;
	private string[] selStrings = new string[] {"Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Level 6", "Level 7", "Level 8", "Level 9", "Level 10", "Level 11", "Level 12", "Level 13", "Level 14", "Level 15"};

	//PlayerController pController;

	Rect guiMenuPos = new Rect (Screen.width * 0.5f - 75, Screen.height * 0.3f, 150, 150);

	private static int level;
	private static int number;
	public static bool musicPlaying = false;

	// Use this for initialization
	void Start () 
	{
		//gameState = GameStates.TITLE;

		if (!_created) 
		{
			_created = true;
			DontDestroyOnLoad (gameObject);
		} else
			Destroy (gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		if (AudioManager.me != null && musicPlaying == false)
		{
			AudioManager.me.PlayClip(0, AudioChannel.Music);
			musicPlaying = true;
		}

		if (gameState == GameStates.LOADNEXTLEVEL)
		{
			gameState = GameStates.PLAY;
			Time.timeScale = 1.0f;

			Application.LoadLevel("Level" + (selGridInt + 1));
		}
	}

	void OnGUI()
	{
		//GUI.skin = ______ ;
		if (gameState == GameStates.TITLE) 
		{
			GUILayout.BeginArea (guiMenuPos);
			GUILayout.BeginVertical (); //("box");	

			if (GUILayout.Button ("Start")) {
				AudioManager.me.PlayClip(2, AudioChannel.SoundEffects);
				gameState = GameStates.LEVELSELECT;
			}		

			if (GUILayout.Button ("Options")) {
				AudioManager.me.PlayClip(2, AudioChannel.SoundEffects);
				gameState = GameStates.OPTIONS;
			}

			if (GUILayout.Button ("Quit")) {
				AudioManager.me.PlayClip(2, AudioChannel.SoundEffects);
				gameState = GameStates.EXIT;
			}

			GUILayout.EndVertical ();
			GUILayout.EndArea ();
		}		
		else if (gameState == GameStates.LEVELSELECT) 
		{
			selGridInt = GUI.SelectionGrid(new Rect(Screen.width / 2 + 40, 25, 320, 100), selGridInt, selStrings, 5);
			
			if (GUI.Button(new Rect(Screen.width - 175, Screen.height - 50, 100, 20), "Accept") && selGridInt >= 0) {
				AudioManager.me.PlayClip(2, AudioChannel.SoundEffects);
				Application.LoadLevel("Level" + (selGridInt + 1));
				Level = selGridInt + 1;
				gameState = GameStates.PLAY;
			}
			if (GUI.Button(new Rect(25, Screen.height - 50, 100, 20), "Back")) {
				AudioManager.me.PlayClip(2, AudioChannel.SoundEffects);
				gameState = GameStates.TITLE;
				//Application.LoadLevel("Main Menu");
			}
		}
		else if (gameState == GameStates.PLAY) 
		{
			if (Input.GetKeyDown(KeyCode.Escape)) 
			{
				AudioManager.me.PlayClip(2, AudioChannel.SoundEffects);
				//pController = GameObject.FindObjectOfType<PlayerController>();
				//Debug.Log(pController.ToString());
				gameState = GameStates.PAUSE;
				Time.timeScale = 0;
			}
		}
		else if (gameState == GameStates.PAUSE) 
		{
			//pController.IsFrozen = false;
			GUILayout.BeginArea (guiMenuPos);
			GUILayout.BeginVertical ();
			if (GUILayout.Button("Resume"))
			{
				AudioManager.me.PlayClip(2, AudioChannel.SoundEffects);
				gameState = GameStates.PLAY;
				Time.timeScale = 1;
			}
			if (GUILayout.Button ("Return to Main Menu")) {
				AudioManager.me.PlayClip(2, AudioChannel.SoundEffects);
				gameState = GameStates.TITLE;
				Application.LoadLevel("Main Menu");
			}			
			GUILayout.EndVertical ();
			GUILayout.EndArea ();
		}

		else if (gameState == GameStates.OPTIONS) 
		{
			GUI.Label( new Rect( 400, 200, 100, 100), "Options");
			GUILayout.BeginArea (guiMenuPos);
			GUILayout.BeginVertical ();
			if (GUILayout.Button ("Return")) {
				AudioManager.me.PlayClip(2, AudioChannel.SoundEffects);
				gameState = GameStates.TITLE;
			}
			GUILayout.EndVertical ();
			GUILayout.EndArea ();
		}
		else if (gameState == GameStates.EXIT) 
		{
			GUI.Label( new Rect( 400, 200, 100, 100), "Are you sure?");

			GUILayout.BeginArea (guiMenuPos);
			GUILayout.BeginVertical ();

			if (GUILayout.Button ("Yes")) {
				AudioManager.me.PlayClip(2, AudioChannel.SoundEffects);
				Application.Quit ();
			}
					
			if (GUILayout.Button ("No")) {
				AudioManager.me.PlayClip(2, AudioChannel.SoundEffects);
				gameState = GameStates.TITLE;
			}

			GUILayout.EndVertical ();
			GUILayout.EndArea ();
		}
	}


	//StartCoroutine("Name");
	/*IEnumerator Name()
	{
		yield return new WaitForSeconds(1.0f); //pause here for a bit
			Instantiate ();// create something

	} */

	public static GameStates ChangeState
	{
		get { return gameState; }
		set { gameState = value; }
	}

	public static int Level
	{
		get { return level; }
		set { level = value; }
	}
	public static int Number
	{
		get { return number; }
		set { number = value; }
	}
}
