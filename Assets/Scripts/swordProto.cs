﻿using UnityEngine;
using System.Collections;

public class swordProto : MonoBehaviour {

	public float GridX;
	public float GridY;

	stairsScript stairs;
	GoldProto gold;

	// Use this for initialization
	void Start () {
		//Comps
		stairs = FindObjectOfType<stairsScript>();
		gold = FindObjectOfType<GoldProto>();

		RandomXY();

		//If sword spawns on the same X,Y as stairs or gold
		while ((GridX == stairs.GridX && GridY == stairs.GridY) || (GridX == gold.GridX && GridY == gold.GridY))
		{
			RandomXY();
		}

		//Set position
		transform.position = new Vector3(GridX, GridY, -2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void RandomXY()
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
	}
}
