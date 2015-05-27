using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;

public class MovementProto : MonoBehaviour
{
	private float TileH;
	private float TileW;

	public GameObject MoveBox;
	public GameObject Enemy;

	public bool HasMoved;
	public float Health;
	public float GridX;
	public float GridY;
	public float GridXMax;
	public float GridXMin;
	public float GridYMax;
	public float GridYMin;

	void Start ()
	{
		//Default values, change these to wherever this needs to spawn
		HasMoved = false;
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

	}

	void Attack()
	{
		//ATTACK BY PLAYER LOGIC GOES HERE
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			HasMoved = true;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow) && GridX < GridXMax)
		{
			if (GridX + 1 == Enemy.GetComponent<EnemyProto>().GridX && GridY == Enemy.GetComponent<EnemyProto>().GridY)
			{
				Attack();
			}
			else
			{
				GridX++;
			}
			HasMoved = true;
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow) && GridX > GridXMin)
		{
			if (GridX - 1 == Enemy.GetComponent<EnemyProto>().GridX && GridY == Enemy.GetComponent<EnemyProto>().GridY)
			{
				Attack();
			}
			else
			{
				GridX--;
			}
			HasMoved = true;
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow) && GridY < GridYMax)
		{
			if (GridY + 1 == Enemy.GetComponent<EnemyProto>().GridY && GridX == Enemy.GetComponent<EnemyProto>().GridX)
			{
				Attack();
			}
			else
			{
				GridY++;
			}
			HasMoved = true;
		}

		else if (Input.GetKeyDown(KeyCode.DownArrow) && GridY > GridXMin)
		{
			if (GridY - 1 == Enemy.GetComponent<EnemyProto>().GridY && GridX == Enemy.GetComponent<EnemyProto>().GridX)
			{
				Attack();
			}
			else
			{
				GridY--;
			}
			HasMoved = true;
		}
		transform.Translate((GridX * TileW) - transform.localPosition.x, (GridY * TileH) - transform.localPosition.y, 0);

	}
}
