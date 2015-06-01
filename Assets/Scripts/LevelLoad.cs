using UnityEngine;
using System.Collections;

public class LevelLoad : MonoBehaviour {

	public int totalGold;
	private int maxGold;
	
	public int totalEnemies;
	public int currentLevel = 0;

	public GameObject gold;
	public GameObject enemy;
	public GameObject player;
	public GameObject stairs;

	//TODO: Restore some health per level

	//Delagate level load for stairs
	public delegate void dLevelLoad();
	public dLevelLoad OnLevelLoad;

	void Awake()
	{
		OnLevelLoad += LoadNext;
	}

	// Use this for initialization
	void Start () {
		//Clear Level
		ClearGoldStairs();

		//Load player and enemies
		LoadPlayer();
		LoadCarbon();

		//Loads Stairs
		LoadStairs();
	}
	
	// Update is called once per frame
	void Update () {
		LoadGold();
	}

	//Loads gold at scene start and
	//Whenever there is less gold in the scene than max
	void LoadGold()
	{
		//Set max gold based on current level
		maxGold = 3 + currentLevel;
		if (totalGold < maxGold)
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

	void LoadPlayer()
	{
		

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
			if (gameObject.transform.GetChild(i).tag == "Gold" || gameObject.transform.GetChild(i).tag == "stairs")
			Destroy(gameObject.transform.GetChild(i).gameObject);
		}
	}




	//Load the next level
	public void LoadNext()
	{
		ClearGoldStairs();
		LoadStairs();
		LoadGold();
		currentLevel++;
	}
}
