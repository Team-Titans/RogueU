using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getName : MonoBehaviour {

    public Text TextToKeep;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Object.DontDestroyOnLoad(gameObject);
	}
}
