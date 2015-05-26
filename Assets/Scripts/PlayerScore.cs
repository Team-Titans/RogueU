using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	public int score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//Pickup Gold on Collision + Add Score
		if (col.gameObject.tag == "Gold")
		{
			Debug.Log("He touched the gold!");
			Destroy(col.gameObject);
			GetComponentInParent<LevelLoad>().totalGold--;
			score += (75 * GetComponentInParent<LevelLoad>().totalEnemies);
		}
	}
}
