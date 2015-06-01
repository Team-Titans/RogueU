﻿using UnityEngine;
using System.Collections;

public class EnemyProto : MonoBehaviour {

	public float GridX;
	public float GridY;

	private float TileW;
	private float TileH;
	public float Health;

	public GameObject Player;
	private bool firstTurn = true;
	public bool isAlive;
	// Use this for initialization
	void Start ()
	{
		Health = 20;
		isAlive = true;
		//This gets the width and height of the current item
		TileW = transform.localScale.x;
		TileH = transform.localScale.y;

		GridX = -5.5f;
		GridY = -5.5f;
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

	public void ResetEnemy()
	{

	}

	public void IsKill()
	{
		isAlive = false;
		Debug.Log("ENEMY IS DEAD");
		GridX += 100000;
		GridY += 100000;
	}

	public void Attack()
	{
		//Subtracts health
		Player.GetComponent<MovementProto>().Health -= 3;
		Debug.Log("ENEMY ATTACK");
		if (Player.GetComponent<MovementProto>().Health < 1)
		{
			//PLAYER IS DEAD LOGIC GOES HERE (to console, isalive, loadlevel)
			Debug.Log("PLAYER IS DEAD");
			Player.GetComponent<MovementProto>().isAlive = false;
			Application.LoadLevel(Application.loadedLevel + 1);
			//Application.Quit();
		}
	}

	void Update ()
	{
		if (!firstTurn)
		{
			if (isAlive)
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
		}
		else 
		{
			firstTurn = false;
		}
		transform.Translate((GridX * TileW) - transform.localPosition.x, (GridY * TileH) - transform.localPosition.y, 0);
	}
}
