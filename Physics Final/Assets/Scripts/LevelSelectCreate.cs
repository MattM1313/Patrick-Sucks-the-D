using UnityEngine;
using System.Collections;

public class LevelSelectCreate : MonoBehaviour {

	public int selGridInt;
	private string[] selStrings = new string[] {"Grid 1", "Grid 2", "Grid 3", "Grid 4", "Grid 5", "Grid 6", "Grid 7", "Grid 8", "Grid 9", "Grid 10", "Grid 11", "Grid 12", "Grid 13", "Grid 14", "Grid 15"};

	void OnGUI() 
	{
		selGridInt = GUI.SelectionGrid(new Rect(25, 25, 575, 300), selGridInt, selStrings, 5);
		Application.LoadLevel(selGridInt);
	}

	void OnMouseOver()
	{

	}

}
