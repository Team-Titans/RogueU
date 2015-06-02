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
			PlayerPrefs.SetString("Player", NameField.text);
			Application.LoadLevel("GameLoop");
			Debug.Log("Level Loading");
		}
	}
	// Update is called once per frame
	void Update ()
	{
        if (Input.GetKeyDown(KeyCode.P))
		{
			PlayerPrefs.DeleteAll();
		}

	    if(Input.GetKeyDown(KeyCode.Return))
        {
			ChangeLevel();
        }
	}
}
