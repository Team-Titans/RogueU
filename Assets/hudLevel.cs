using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class hudLevel : MonoBehaviour {

	LevelLoad levelLoad;
	Text text;
	// Use this for initialization
	void Start () {
		levelLoad = FindObjectOfType<LevelLoad>();
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "L: " + levelLoad.currentLevel.ToString();
	}
}
