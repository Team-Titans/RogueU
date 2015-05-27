using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class hudScript : MonoBehaviour {

	void Awake()
	{
		PlayerScore scoreDisp = null;
		scoreDisp = GameObject.FindObjectOfType<PlayerScore>();
		if (scoreDisp != null)
		{
			scoreDisp.OnScoreChanged += UpdateScoreDisplay;
		}
	}

	public void UpdateScoreDisplay(int score)
	{
		Text temp = gameObject.GetComponent<Text>();
		if (temp != null)
		{
			temp.text = "Score: " + score.ToString();
		}
	}
}
