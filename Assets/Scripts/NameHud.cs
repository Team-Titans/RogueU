using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NameHud : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text>().text += PlayerPrefs.GetString("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
