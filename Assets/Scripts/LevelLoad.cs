﻿using UnityEngine;
using System.Collections;

public class LevelLoad : MonoBehaviour {

	public int totalGold;
	public int maxGold;
	
	public int totalEnemies;
	public int currentLevel;

	public GameObject gold;
	public GameObject enemy;
	public GameObject player;
	public GameObject stairs;
	public GameObject sword;

	//TODO: Restore some health per level

	//Delagate level load for stairs
	public delegate void dLevelLoad();
	public dLevelLoad OnLevelLoad;

	void Awake()
	{
		OnLevelLoad += LoadNext;
		PlayerPrefs.SetInt("PlayerLevel", currentLevel);
	}

	// Use this for initialization
	void Start () {
		//Load player and enemies
		//LoadPlayer();
		LoadCarbon();

		//Loads Stairs
		LoadStairs();

		//Load Gold
		LoadGold();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	//Loads gold at scene start and
	//Whenever there is less gold in the scene than max
	void LoadGold()
	{
		//Set max gold based on current level
		maxGold = 1 + currentLevel;
		while (totalGold < maxGold)
		{
			GameObject newGold;
			newGold = Instantiate(gold);
			newGold.transform.SetParent(gameObject.transform);
			totalGold++;
		}
	}

	//Loads initial enemies of the level
	void LoadCarbon()
	{
		GameObject newEnemy;
		newEnemy = Instantiate(enemy);
		newEnemy.transform.SetParent(gameObject.transform);


		GameObject newPlayer;
		newPlayer = Instantiate(player);
		newPlayer.transform.SetParent(gameObject.transform);

		//Initialize EnemyProto Script
		EnemyProto scriptEnemy = newEnemy.GetComponent<EnemyProto>();
		if (scriptEnemy != null)
		{
			scriptEnemy.Player = newPlayer;
		}

		//Initialze Player movement proto script
		MovementProto scriptPlayer = newPlayer.GetComponent<MovementProto>();
		if (scriptPlayer != null)
		{
			scriptPlayer.MoveBox = gameObject;
			scriptPlayer.Enemy = newEnemy;
		}

	}

	void ResetEnemy()
	{
		EnemyProto enemyScript = GetComponentInChildren<EnemyProto>();
		if (enemyScript != null)
		{
			enemyScript.Reset();
		}
		else
		{
			//debug.log("YA FUCKED UP");
		}
	}

	void LoadSword()
	{
		GameObject newSword;
		newSword = Instantiate(sword);
		newSword.transform.SetParent(gameObject.transform);

	}

	//Loads the stairs initial position on a floor
	void LoadStairs()
	{
		GameObject newStairs;
		newStairs = Instantiate(stairs);
		newStairs.transform.SetParent(gameObject.transform);
	}

	//Clears Children of the current GameObject
	void ClearGoldStairs()
	{
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			if (gameObject.transform.GetChild(i).tag == "Gold" || gameObject.transform.GetChild(i).tag == "stairs" || gameObject.transform.GetChild(i).tag == "sword")
			Destroy(gameObject.transform.GetChild(i).gameObject);
		}
	}




	//Load the next level
	public void LoadNext()
	{
		ClearGoldStairs();
		LoadStairs();
		currentLevel++;
		if (currentLevel % 5 == 0)
		{
			LoadSword();
		}
		PlayerPrefs.SetInt("PlayerLevel", currentLevel);
		totalGold = 0;
		LoadGold();
		ResetEnemy();
	}
}
