using UnityEngine;
using System.Collections;

public class stairsScript : MonoBehaviour
{
	public float GridX;
	public float GridY;

	// Use this for initialization
	void Start () {
		//Default values, change these to wherever this needs to spawn
		GridX = Random.Range(0, 15) - 7;
		if (GridX < 0)
		{
			GridX -= .5f;
		}
		else
		{
			GridX += .5f;
		}
		GridY = Random.Range(0, 15) - 7;
		if (GridY < 0)
		{
			GridY -= .5f;
		}
		else
		{
			GridY += .5f;
		}

		//This gets the width and height of the current item
		//Set position
		transform.position = new Vector3(GridX, GridY, -3);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
