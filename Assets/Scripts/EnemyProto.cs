using UnityEngine;
using System.Collections;

public class EnemyProto : MonoBehaviour {

	public float GridX;
	public float GridY;

	private float TileW;
	private float TileH;

	public GameObject Player;
	private bool firstTurn = true;
	// Use this for initialization
	void Start ()
	{
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
		TileW = transform.localScale.x;
		TileH = transform.localScale.y;

		//Set position
		transform.position = new Vector3(GridX, GridY, -2);

	}
	bool IsBeside(float tX, float tY, float uX, float uY)
	{
		if (tX + 1 == uX && tY == uY)
		{
			return true;
		}
		if (tX - 1 == uX && tY == uY)
		{
			return true;
		}
		if (tY + 1 == uY && tX == uX)
		{
			return true;
		}
		if (tY - 1 == uY && tX == uX)
		{
			return true;
		}

		return false;
	}

	void Attack()
	{
		Debug.Log("ENEMY ATTACK");
	}

	void Update ()
	{
		//debug bullshit
		//firstTurn = true;
		if (!firstTurn)
		{
			if (Player.GetComponent<MovementProto>().HasMoved && !IsBeside(GridX, GridY, Player.GetComponent<MovementProto>().GridX, Player.GetComponent<MovementProto>().GridY))
			{
				Player.GetComponent<MovementProto>().HasMoved = false;
				//PUT ENEMY TURN LOGIC HERE
				Debug.Log("ENEMY TURN");

				if (Mathf.Abs(Player.GetComponent<MovementProto>().GridX - GridX) > Mathf.Abs(Player.GetComponent<MovementProto>().GridY - GridY))
				{
					if (GridX >= Player.GetComponent<MovementProto>().GridX)
					{
						GridX--;
					}
					else
					{
						GridX++;
					}
				}
				else
				{
					if (GridY >= Player.GetComponent<MovementProto>().GridY)
					{
						GridY--;
					}
					else
					{
						GridY++;
					}
				}
			}
			else if (Player.GetComponent<MovementProto>().HasMoved)
			{
				Player.GetComponent<MovementProto>().HasMoved = false;
				Attack();
			}
		}
		else 
		{

			firstTurn = false;
		}
		transform.Translate((GridX * TileW) - transform.localPosition.x, (GridY * TileH) - transform.localPosition.y, 0);
	}
}
