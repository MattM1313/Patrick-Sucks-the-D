using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static bool _created;
    // gameState Option should display a different version of Playstate Options

	public enum GameStates {TITLE, PLAY, LEVELSELECT, PAUSE, OPTIONS, EXIT};
	private static GameStates gameState;

	public int selGridInt;
	private string[] selStrings = new string[] {"Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Level 6", "Level 7", "Level 8", "Level 9", "Level 10", "Level 11", "Level 12", "Level 13", "Level 14", "Level 15"};

	//PlayerController pController;

	Rect guiMenuPos = new Rect (Screen.width * 0.5f - 75, Screen.height * 0.3f, 150, 150);

	private static int level;
    private static int number;

	// Use this for initialization
	void Start () 
	{
        gameState = GameStates.TITLE;

		if (!_created) 
		{
			_created = true;
			DontDestroyOnLoad (gameObject);
		} else
			Destroy (gameObject);

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		//GUI.skin = ______ ;
		if (gameState == GameStates.TITLE) 
		{
			GUILayout.BeginArea (guiMenuPos);
			GUILayout.BeginVertical (); //("box");	

			if (GUILayout.Button ("Start")) {
				gameState = GameStates.LEVELSELECT;
			}		

			if (GUILayout.Button ("Options")) {
				gameState = GameStates.OPTIONS;
			}

			if (GUILayout.Button ("Quit")) {
				gameState = GameStates.EXIT;
			}

			GUILayout.EndVertical ();
			GUILayout.EndArea ();
		}		
		else if (gameState == GameStates.LEVELSELECT) 
		{
			selGridInt = GUI.SelectionGrid(new Rect(480, 25, 320, 100), selGridInt, selStrings, 5);
			
			if (GUI.Button(new Rect(680, 430, 100, 20), "Accept") && selGridInt >= 0) {
				Application.LoadLevel("Level" + (selGridInt + 1));
				gameState = GameStates.PLAY;
			}
			if (GUI.Button(new Rect(25, 430, 100, 20), "Back")) {
				Application.LoadLevel("Main Menu");
			}
		}
		else if (gameState == GameStates.PLAY) 
		{
			if (Input.GetKeyDown(KeyCode.Escape)) 
			{
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
			if (GUILayout.Button ("Resume")) {
				gameState = GameStates.PLAY;
				Time.timeScale = 1;
			}
			if (GUILayout.Button ("Return to Main Menu")) {
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
				Application.Quit ();
			}
					
			if (GUILayout.Button ("No")) {
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
