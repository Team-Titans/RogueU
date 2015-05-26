using UnityEngine;
using System.Collections;

public class seek : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.x < gameObject.transform.position.x)
        {
            //gameObject.transform.position.x += 10;
            gameObject.transform.Translate(new Vector3(-gameObject.transform.localScale.x * 5f, 0, 0));
        }
        else if (player.transform.position.x > gameObject.transform.position.x)
        {
            //gameObject.transform.position.x += 10;
            gameObject.transform.Translate(new Vector3(gameObject.transform.localScale.x * 5f , 0, 0));
        }
        else if (player.transform.position.y < gameObject.transform.position.y)
        {
            //gameObject.transform.position.x += 10;
            gameObject.transform.Translate(new Vector3(0, -gameObject.transform.localScale.x * 5f, 0));
        }
        else
        {
            gameObject.transform.Translate(new Vector3(0, gameObject.transform.localScale.x * 5f, 0));
        }
	}
}
