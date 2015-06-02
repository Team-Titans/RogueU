using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NameHud : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text>().text += PlayerPrefs.GetString("PlayerName");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
