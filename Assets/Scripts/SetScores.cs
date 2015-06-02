using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets.Scripts.Classes;

public class SetScores : MonoBehaviour {

	public Text GraveBox;
	public Text HiScoreBox;

	public List<HighScore> HighScores;

	// Use this for initialization
	void Start()
	{
		HighScores = new List<HighScore>();
		HighScores.Clear();
		for (int i = 1; i < 11; i++)
		{
			if (PlayerPrefs.HasKey("hiscore" + i))
			{
				HighScores.Add(new HighScore(PlayerPrefs.GetInt("hiscore" + i), PlayerPrefs.GetString("hiscore" + i)));
			}
			else
			{
				break;
			}
		}

		if (HighScores.Count == 1)
		{
			HighScores.Add(new HighScore(PlayerPrefs.GetInt("Player"), PlayerPrefs.GetString("Player")));
		}

		//FIX THE SORT
		HighScores.Sort();
		HighScores.Reverse();

		int foo = 1;
		foreach (HighScore tScore in HighScores)
		{
			HiScoreBox.text += tScore.Score + " AU\t\t " + tScore.Name + " was killed by a Slime on Level " + PlayerPrefs.GetInt("PlayerLevel") + ".\n";
			PlayerPrefs.SetInt("hiscore" + foo, tScore.Score);
			PlayerPrefs.SetString("hiscore" + foo, tScore.Name);
			foo++;
		}
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Application.LoadLevel("MainMenu");
		}
	}
}
