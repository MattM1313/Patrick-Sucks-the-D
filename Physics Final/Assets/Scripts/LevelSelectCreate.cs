using UnityEngine;
using System.Collections;

public class LevelSelectCreate : MonoBehaviour {

	public int selGridInt;
	private string[] selStrings = new string[] {"Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Level 6", "Level 7", "Level 8", "Level 9", "Level 10", "Level 11", "Level 12", "Level 13", "Level 14", "Level 15"};

	void OnGUI() 
	{
		selGridInt = GUI.SelectionGrid(new Rect(500, 25, 320, 100), selGridInt, selStrings, 5);

        if (GUI.Button(new Rect(680, 430, 100, 20), "Accept") && selGridInt >= 0) {
            Application.LoadLevel("Level" + (selGridInt + 1));
        }
	}

	void OnMouseOver()
	{

	}

}
