using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class menu : MonoBehaviour {

    public Text playerName;
    public Button StartButton;
    public Button QuitButton;

	// Use this for initialization
	void Start () {
        playerName = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        playerName = GetComponent<Text>();

	    if(Input.GetKeyDown(KeyCode.Return))
        {
            PlayerPrefs.SetString("Player", playerName.text);
            Application.LoadLevel("GameLoop");
            Debug.Log("Level Loading");

            //Debug.Log(PlayerPrefs.GetString("name"));
        }
	}
}
