using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine.UI;

public class MovementProto : MonoBehaviour
{
	private float TileH;
	private float TileW;

    public string Name;
	public GameObject MoveBox;
	public GameObject Enemy;

	public bool isAlive;
	public bool HasMoved;
	public float GridX;
	public float GridY;
	public float GridXMax;
	public float GridXMin;
	public float GridYMax;
	public float GridYMin;

	//Changes to health
	public delegate void dHealthChanged(int num);
	public dHealthChanged OnHealthChanged;
	public int maxHealth = 20;

	//Get Set HP
	private int _health;
	public int Health
	{
		get { return _health; }
		set
		{
			if (_health != value)
			{
				_health = value;
				if (OnHealthChanged != null)
				{
					OnHealthChanged(_health);
				}
			}
		}
	}

	//Changes to Attack Power
	public delegate void dAttackChanged(int num);
	public dAttackChanged OnAttackChanged;

	//Get Set Attack Power
	private int _attackPower;
	public int AttackPower
	{
		get { return _attackPower; }
		set
		{
			if (_attackPower != value)
			{
				_attackPower = value;
				if (OnAttackChanged != null)
				{
					OnAttackChanged(_attackPower);
				}
			}
		}
	}


	// Use this for initialization
	void Start ()
	{
		//Initial Player values
		isAlive = true;
		Health = 20;
		AttackPower = 7;

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

		transform.position = new Vector3(GridX, GridY, -3);
		
	}

	void Attack()
	{
		// Subtract health from enemy
		Enemy.GetComponent<EnemyProto>().Health -= AttackPower;
		Debug.Log("PLAYER ATTACK");
		if (Enemy.GetComponent<EnemyProto>().Health < 1)
		{
			//PUT ENEMY DEATH LOGIC HERE
			Enemy.GetComponent<EnemyProto>().IsKill();
			//Application.Quit();
		}
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			Debug.Log("SUICIDE WOULD BE NICE AND NEAT");
			for (int i = 0; i < 10; i++)
			{
				Enemy.GetComponent<EnemyProto>().Attack();
			}
		}
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
	void OnTriggerEnter2D(Collider2D col)
	{
		//Pickup Gold on Collision + Add Score
		if (col.gameObject.tag == "Gold")
		{
			Debug.Log("He touched the gold!");
			Destroy(col.gameObject);

			LevelLoad loaded = GetComponentInParent<LevelLoad>();
			if (loaded != null)
			{
				loaded.totalGold--;
				PlayerScore scoreDisp = GameObject.FindObjectOfType<PlayerScore>();

				if (scoreDisp != null)
				{
					scoreDisp.Score += 75;
				}
			}
		}

		if (col.gameObject.tag == "stairs")
		{
			Debug.Log("player climbed stairs");

			//Restore some health and 1 to max health
			maxHealth += 1;
			if (Health < maxHealth)
			{
				Health += 2;
				if (Health > maxHealth)
					Health = maxHealth;
			}

			//Load level script and start level
			LevelLoad loadLevel = null;
			loadLevel = GameObject.FindObjectOfType<LevelLoad>();
			if (loadLevel != null)
			{
				loadLevel.OnLevelLoad();
			}
		}

		if (col.gameObject.tag == "sword")
		{
			Debug.Log("Picked up a sword! Swing it!");
			//Attack Power Up!
			AttackPower += 3;
			Destroy(col.gameObject);
		}
	}
}
