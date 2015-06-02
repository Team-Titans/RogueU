using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class getHighScores : MonoBehaviour {
    public struct PlayerScore
    {
        public int score;
        public string name;
        public string killedBy;
    }

    public List<PlayerScore> scoreList = new List<PlayerScore>();
    public PlayerScore temp = new PlayerScore();
    Text highScores;

    private int count = 500;

	// Use this for initialization
	void Start () {
        
        

        highScores = GetComponent<Text>();

        temp.score = PlayerPrefs.GetInt("finalScore");
        temp.name = PlayerPrefs.GetString("name");
        temp.killedBy = "slime";

        scoreList.Add(temp);
	}
	
	// Update is called once per frame
	void Update () {
        foreach (PlayerScore player in scoreList)
        {
            //GUIText t = new GUIText();
            //t.text = player.name + " got killed by " + player.killedBy;


            //var rect = new Rect(500, count, 100, 10);
            //t.text = GUI.TextField(rect, t.text);
            
            ////t.text = player.name + " got killed by " + player.killedBy;

            
            //t.transform.position = new Vector3(500.0f, count, 0.0f);

            highScores.text = player.name + " got killed by " + player.killedBy;
            //highScores.transform.position = new Vector3(500.0f, count, 0.0f);
            //newText.transform.position(10f, 10f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            temp.score = 1000;
            temp.name = "grjehgk";
            temp.killedBy = "slime";

            
            scoreList.Add(temp);

            count += 100;
        }

        //temp.t.text = PlayerPrefs.GetInt("finalScore").ToString();
        //temp.name = PlayerPrefs.GetString("name");

        //temp.name = "gnre";
        //temp.killedBy = "slime";
        ////highScores.text = "blahc got killed by blah";
        //highScores.text = (temp.name + " got killed by " + temp.killedBy);
        
	}
}
