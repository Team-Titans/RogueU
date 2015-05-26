using UnityEngine;
using System.Collections;

public class LevelLoad : MonoBehaviour {

	public int totalGold;
	private int maxGold;
	public int totalEnemies;
	private int currentLevel = 0;
	public GameObject gold;



	// Use this for initialization
	void Start () {
		currentLevel += 1;
		totalGold = 0;
	}
	
	// Update is called once per frame
	void Update () {
		LoadGold();
	}

	void LoadGold()
	{
		//Set max gold based on current level
		
		maxGold = 1 + currentLevel;
		if (totalGold < maxGold)
		{
			GameObject newgold;
			newgold = Instantiate(gold);
			newgold.transform.SetParent(gameObject.transform);
			totalGold++;
		}
	}
}
