﻿using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;

public class GoldProto : MonoBehaviour
{
	public GameObject MoveBox;

	public float GridX;
	public float GridY;

	// Use this for initialization
	void Start()
	{
		//Default values, change these to wherever this needs to spawn
		GridX = Random.Range(0,15) - 7;
		if (GridX < 0)
		{
			GridX -= .5f;
		}
		else
		{
			GridX += .5f;
		}
		GridY = Random.Range(0,15) - 7;
		if (GridY < 0)
		{
			GridY -= .5f;
		}
		else
		{
			GridY += .5f;
		}
		
		//Set position
		transform.position = new Vector3(GridX, GridY, -2);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
