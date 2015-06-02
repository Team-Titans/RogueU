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
		GraveBox.text += PlayerPrefs.GetString("PlayerName") + "\n\n" + PlayerPrefs.GetInt("PlayerScore") + " AU\n\nDeath by\nSlime";

		for (int i = 1; i < 11; i++)
		{

			if (PlayerPrefs.HasKey("hiscore" + i) && PlayerPrefs.HasKey("hiname" + i))
			{
				HighScores.Add(new HighScore(PlayerPrefs.GetInt("hiscore" + i), PlayerPrefs.GetString("hiname" + i)));
			}
			else
			{
				break;
			}
		}

		
		HighScores.Add(new HighScore(PlayerPrefs.GetInt("PlayerScore"), PlayerPrefs.GetString("PlayerName")));

		HighScores.Sort();
		HighScores.Reverse();

		/*
		int foo = 1;
		foreach (HighScore tScore in HighScores)
		{
			HiScoreBox.text += tScore.Score + " AU\t\t " + tScore.Name + " was killed by a Slime"+ ".\n";
			//HiScoreBox.text += tScore.Score + " AU\t\t " + tScore.Name + " was killed by a Slime" + " on Level " + PlayerPrefs.GetInt("PlayerLevel") + ".\n";
			PlayerPrefs.SetInt("hiscore" + foo, tScore.Score);
			PlayerPrefs.SetString("hiname" + foo, tScore.Name);
			foo++;
			if (foo++ > 10)
				break;
		}
		*/
		for (int i = 0; i < 10; i++)
		{
			if (i == HighScores.Count)
				break;
			HiScoreBox.text += HighScores[i].Score + " AU\t\t " + HighScores[i].Name + " was killed by a Slime" + ".\n";
			//HiScoreBox.text += HighScores[i].Score + " AU\t\t " + HighScores[i].Name + " was killed by a Slime" + " on Level " + PlayerPrefs.GetInt("PlayerLevel") + ".\n";
			PlayerPrefs.SetInt("hiscore" + (i + 1), HighScores[i].Score);
			PlayerPrefs.SetString("hiname" + (i + 1), HighScores[i].Name);
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
