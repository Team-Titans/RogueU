using UnityEngine;
using System.Collections;
using Assets.Scripts;
public class TileProto : MonoBehaviour
{

	TileHandler TileManager;

	// Use this for initialization
	void Start ()
	{
		TileManager = new TileHandler();
	}
	
	// Update is called once per frame
	void Update ()
	{
        // when player dies go to scoreScreen scene
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // not working yet
            Application.LoadLevel("scoreScreen");
        }
	}
}
