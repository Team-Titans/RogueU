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

	//Comp
	EnemyProto enemy;
	LevelLoad loaded;
	PlayerScore scoreDisp;

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
		//Comps
		enemy = Enemy.GetComponent<EnemyProto>();
		loaded = GetComponentInParent<LevelLoad>();
		scoreDisp = GameObject.FindObjectOfType<PlayerScore>();

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
		enemy.Health -= AttackPower;
		//debug.log("PLAYER ATTACK");
		if (enemy.Health < 1)
		{
			//PUT ENEMY DEATH LOGIC HERE
			enemy.IsKill();
			//Application.Quit();
		}
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			//debug.log("SUICIDE WOULD BE NICE AND NEAT");
			for (int i = 0; i < 10; i++)
			{
				enemy.Attack();
			}
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			HasMoved = true;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow) && GridX < GridXMax)
		{
			if (GridX + 1 == enemy.GridX && GridY == enemy.GridY)
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
			if (GridX - 1 == enemy.GridX && GridY == enemy.GridY)
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
			if (GridY + 1 == enemy.GridY && GridX == enemy.GridX)
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
			if (GridY - 1 == enemy.GridY && GridX == enemy.GridX)
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
			//debug.log("He touched the gold!");
			Destroy(col.gameObject);

			if (loaded != null)
			{
				loaded.totalGold--;

				if (scoreDisp != null)
				{
					scoreDisp.Score += 75;
				}
			}
		}

		else if (col.gameObject.tag == "stairs")
		{
			//debug.log("player climbed stairs");

			//Restore some health and 1 to max health
			maxHealth += 1;
			if (Health < maxHealth)
			{
				Health += 2;
				if (Health > maxHealth)
					Health = maxHealth;
			}

			//Load level script and start level
			LevelLoad loadLevel =  GameObject.FindObjectOfType<LevelLoad>();
			if (loadLevel != null)
			{
				loadLevel.OnLevelLoad();
			}
		}

		else if (col.gameObject.tag == "sword")
		{
			//debug.log("Picked up a sword! Swing it!");
			//Attack Power Up!
			AttackPower += 3;
			Destroy(col.gameObject);
		}
	}
}
