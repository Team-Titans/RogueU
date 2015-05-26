using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.Translate(new Vector3(-gameObject.transform.localScale.x * 5f, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.Translate(new Vector3(gameObject.transform.localScale.x * 5f, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.Translate(new Vector3(0, gameObject.transform.localScale.x * 5f, 0));
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.Translate(new Vector3(0, -gameObject.transform.localScale.x * 5f, 0));
        }
	}
}
