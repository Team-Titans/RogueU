using UnityEngine;
using System.Collections;

public class EnemyProto : MonoBehaviour {

	private float lastGridX;
	private float lastGridY;
	public GameObject Player;
	private bool firstTurn = true;
	// Use this for initialization
	void Start ()
	{
		lastGridX = Player.GetComponent<MovementProto>().GridX;
		lastGridY = Player.GetComponent<MovementProto>().GridY;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float curGridX = Player.GetComponent<MovementProto>().GridX;
		float curGridY = Player.GetComponent<MovementProto>().GridY;
		if (!firstTurn)
		{
			if (lastGridY != curGridY || lastGridX != curGridX)
			{
				//PUT ENEMY TURN LOGIC HERE
				Debug.Log("ENEMY TURN");
			}
		}
		else 
		{
			firstTurn = false;
		}

		lastGridX = curGridX;
		lastGridY = curGridY;
	}
}
