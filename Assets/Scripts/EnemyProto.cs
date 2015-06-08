using UnityEngine;
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

	private MovementProto player;

	// Use this for initialization
	void Start ()
	{
		Health = 20;
		isAlive = true;		//Default values, change these to wherever this needs to spawn
		GridX = Random.Range(0, 15) - 7;

		//Comp
		player = Player.GetComponent<MovementProto>();

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

		//Check conflicting position / randomize Y
		while (GridY == player.GridY)
		{
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

		//Set position
		transform.position = new Vector3(GridX, GridY, -4);
		
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

	public void Reset()
	{
		Debug.Log("ENEMY RESET");
		Health = 20;
		isAlive = true;		//Default values, change these to wherever this needs to spawn
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
		transform.position = new Vector3(GridX, GridY, -4);
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
		player.Health -= 3;

		Debug.Log("ENEMY ATTACK");
		if (player.Health < 1)
		{
			//PLAYER IS DEAD LOGIC GOES HERE (to console, isalive, loadlevel)
			Debug.Log("PLAYER IS DEAD");
			player.isAlive = false;
			PlayerPrefs.SetInt("PlayerScore", Player.GetComponent<PlayerScore>().Score);
			Application.LoadLevel("scoreScreen");
			//Application.Quit();
		}
	}

	void Update ()
	{
		//debug bullshit
		//firstTurn = true;
		if (!firstTurn)
		{
			if (isAlive)
			{
				if (player.HasMoved && !IsBeside(GridX, GridY, player.GridX, player.GridY))
				{
					player.HasMoved = false;
					//PUT ENEMY TURN LOGIC HERE
					Debug.Log("ENEMY TURN");

					if (Mathf.Abs(player.GridX - GridX) > Mathf.Abs(player.GridY - GridY))
					{
						if (GridX >= player.GridX)
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
						if (GridY >= player.GridY)
						{
							GridY--;
						}
						else
						{
							GridY++;
						}
					}
				}
				else if (player.HasMoved)
				{
					player.HasMoved = false;
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
