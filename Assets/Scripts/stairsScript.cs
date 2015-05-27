using UnityEngine;
using System.Collections;

public class stairsScript : MonoBehaviour {

    public GameObject player;

    public Vector3 v;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        
        if (tag == "stairs")
        {
            Debug.Log("player climbed stairs");
            //player.transform.Translate(v);
            //v = (new Vector3(.125f, .125f, 0));
            gameObject.transform.Translate(gameObject.transform.position.x * (-2), 0 , 0);
            //Destroy(gameObject);
        }
    }
}
