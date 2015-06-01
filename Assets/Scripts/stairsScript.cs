using UnityEngine;
using System.Collections;

public class stairsScript : MonoBehaviour
{
	private float TileH;
	private float TileW;

	public float GridX;
	public float GridY;

	// Use this for initialization
	void Start () {
		//Default values, change these to wherever this needs to spawn
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
		transform.position = new Vector3(GridX, GridY, -2);
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D (Collider2D other)
    {       
        if (tag == "stairs")
        {
            Debug.Log("player climbed stairs");
			
			//Load level script and start level
			LevelLoad loadLevel = null;
			loadLevel = GameObject.FindObjectOfType<LevelLoad>();
			if (loadLevel != null)
			{
				loadLevel.OnLevelLoad();
			}
        }
    }
}
