using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;

public class MovementProto : MonoBehaviour
{
	private float TileH;
	private float TileW;

	public GameObject MoveBox;

	public float Health;
	public float GridX;
	public float GridY;
	public float GridXMax;
	public float GridXMin;
	public float GridYMax;
	public float GridYMin;
	// Use this for initialization
	void Start ()
	{
		//Default values, change these to wherever this needs to spawn
		GridX = 0.5f;
		GridY = 0.5f;


		//This sets the grid constraints and assumes the grid is perfectly square and the middle is zero
		GridXMax = 7 + GridX;
		GridYMax = 7 + GridY;
		GridXMin = -GridXMax;
		GridYMin = -GridYMax;

		//This gets the width and height of the current item
		TileW = transform.localScale.x;
		TileH = transform.localScale.y;

		//Moves this to wherever the default is
		transform.Translate((GridX * TileW) - transform.localPosition.x, (GridY * TileH) - transform.localPosition.y, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetKeyDown(KeyCode.RightArrow) && GridX < GridXMax)
		{
			GridX++;
			
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow) && GridX > GridXMin)
		{
			GridX--;
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow) && GridY < GridYMax)
		{
			GridY++;
		}

		else if (Input.GetKeyDown(KeyCode.DownArrow) && GridY > GridXMin)
		{
			GridY--;
		}
		transform.Translate((GridX * TileW) - transform.localPosition.x, (GridY * TileH) - transform.localPosition.y, 0);

	}
}
