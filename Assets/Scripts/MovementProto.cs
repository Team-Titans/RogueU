using UnityEngine;
using System.Collections;

public class MovementProto : MonoBehaviour
{

	private float TileH;
	private float TileW;
	
	private float GridX;
	private float GridY;
	// Use this for initialization
	void Start () 
	{
		//Default values, change these to wherever this needs to spawn
		GridX = 0;
		GridY = 0;

		//This gets the width and height of the current item
		TileW = transform.localScale.x;
		TileH = transform.localScale.y;

		//Moves this to wherever the
		transform.Translate((GridX * TileW) - transform.localPosition.x, (GridY * TileH) - transform.localPosition.y, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			GridX++;
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			GridX--;
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			GridY++;
		}

		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			GridY--;
		}
		transform.Translate((GridX * TileW) - transform.localPosition.x, (GridY * TileH) - transform.localPosition.y, 0);

	}
}
