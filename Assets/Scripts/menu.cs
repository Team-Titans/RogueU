using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class menu : MonoBehaviour
{
	public Text NameField;

	// Use this for initialization
	void Start ()
	{
		//Screen.SetResolution(1024)
	}
	
	public void ChangeLevel()
	{
		if (NameField.text != "")
		{
			PlayerPrefs.SetString("PlayerName", NameField.text);
			Application.LoadLevel("GameLoop");
			Debug.Log("Level Loading");
		}
		else
		{
			PlayerPrefs.SetString("PlayerName", "Rogue");
			Application.LoadLevel("GameLoop");
		}
	}

	public void Exit()
	{
			Application.Quit();
	}

	// Update is called once per frame
	void Update ()
	{
	    if(Input.GetKeyDown(KeyCode.Return))
        {
			ChangeLevel();
        }
	}
}
