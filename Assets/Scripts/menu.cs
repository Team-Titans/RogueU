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
		
	}
	
	public void ChangeLevel()
	{
		if (NameField.text != "")
		{
			PlayerPrefs.SetString("PlayerName", NameField.text);
			Application.LoadLevel("GameLoop");
			Debug.Log("Level Loading");
		}
	}

	public void Exit()
	{
			Application.Quit();
	}

	// Update is called once per frame
	void Update ()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
		{
			PlayerPrefs.DeleteAll();
		}

	    if(Input.GetKeyDown(KeyCode.Return))
        {
			ChangeLevel();
        }
	}
}
