using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getScore : MonoBehaviour {

    public Text t;
	// Use this for initialization
	void Start () {
        t = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        //t.text = "its over 9000";
        t.text = PlayerPrefs.GetInt("finalScore").ToString();
	}
}
