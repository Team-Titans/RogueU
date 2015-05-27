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

	public bool HasMoved;
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

		transform.Translate((GridX * TileW) - transform.localPosition.x, (GridY * TileH) - transform.localPosition.y, 0);
	}

	void Attack()
	{
		Debug.Log("PLAYER ATTACK");
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
	}
}
