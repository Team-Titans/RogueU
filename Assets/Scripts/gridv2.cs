using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gridv2 : MonoBehaviour
{

	public GameObject tilePrefab;
	public int rows;
	public int cols;
	public float distanceBetweenTiles;

	private List<GameObject> TileList = new List<GameObject>();
	private GameObject[,] gridObjects;

	// Use this for initialization
	void Start()
	{
		CreateGraph();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void CreateTiles()
	{
		float xOffset = 0.0f;
		float yOffset = 0.0f;


		for (int tilesCreated = 0; tilesCreated < cols; tilesCreated++)
		{
			xOffset += distanceBetweenTiles;

			if (tilesCreated % rows == 0)
			{
				yOffset += distanceBetweenTiles;
				xOffset = 0;
			}

			Vector3 position = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, 10);
			Vector3 scale = new Vector3(.1f, .1f, .1f);
			GameObject newTile = Instantiate(tilePrefab, position, transform.rotation) as GameObject;
			newTile.transform.localScale = scale;

		}
	}

	void CreateGraph()
	{
		for (int r = 0; r < rows; r++ )
		{
			for (int c = 0; c < cols; c++)
			{
				Vector3 position = new Vector3(r * .5f, c * .5f, 10);
				Vector3 scale = new Vector3(.1f, .1f, .1f);
				GameObject newTile = Instantiate(tilePrefab, position, transform.rotation) as GameObject;
				newTile.transform.localScale = scale;
				newTile.name = gameObject.name + "item at(" + r + ", " + c + ")";

				TileList.Add(newTile);
				Debug.Log(TileList[0]);
			}
		}
	}
}
