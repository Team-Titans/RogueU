using UnityEngine;
using System.Collections;

public class lighting : MonoBehaviour {

    public GameObject CarbonToFollow;
    public Light DirLight;
    // the game object blackbox
    public GameObject player;

	// Use this for initialization
	void Start () {

        // get blackbox's child == smileman
       // CarbonToFollow.name("smileman").GetComponentInChildren<GameObject>();
        player = CarbonToFollow.GetComponentInChildren<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {

        // levelLoad.cs instantiates a clone of the prefab smileman
        // access clone and you will get the position
        DirLight.transform.position = new Vector3(CarbonToFollow.transform.position.x , CarbonToFollow.transform.position.y , -15);
        Debug.Log(CarbonToFollow.transform.position.x + "," + CarbonToFollow.transform.position.y);
	}
}
