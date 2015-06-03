using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	private int _score = 0;
	public int Score
	{
		get { return _score; }
		set
		{
			if (_score != value)
			{
				_score = value;
				if (OnScoreChanged != null)
				{
					OnScoreChanged(_score);
				}
			}
		}
	}

	public delegate void dScoreChanged(int num);
	public dScoreChanged OnScoreChanged;

	void Start()
	{
		OnScoreChanged += LogScore;
	}

	public void LogScore(int score)
	{
		Debug.Log("The score is: " + score.ToString());
	}

}
