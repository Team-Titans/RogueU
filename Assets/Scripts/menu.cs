using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu : MonoBehaviour {

    public Text playerName;
	// Use this for initialization
	void Start () {
        //playerName = new Text();
        playerName = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        playerName = GetComponent<Text>();
        

	    if(Input.GetKeyDown(KeyCode.Return))
        {
            PlayerPrefs.SetString("name", playerName.text);
            Application.LoadLevel("MasterLoop");
            Debug.Log("Level Loading");

            //Debug.Log(PlayerPrefs.GetString("name"));
        }
	}
}
