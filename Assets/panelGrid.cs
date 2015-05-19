using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class panelGrid : MonoBehaviour {

    public GameObject wall;
    public GameObject empty;
    //public Sprite s;

    //public GameObject panelUI;

	// Use this for initialization
	void Start ()
    {
        addImages();

        foreach (RectTransform child in gameObject.GetComponentsInChildren<RectTransform>())
        {
            Debug.Log(child.position.x + child.name);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.F))
        {

        }
	}

    void addImages()
    {
        RectTransform rec = gameObject.GetComponent<RectTransform>();
        GridLayoutGroup gridLayout = gameObject.GetComponent<GridLayoutGroup>();
        float height = rec.rect.height;
        float width =  rec.rect.width;
        for (int i = 0; i < height/gridLayout.cellSize.y; i++)
        {
            for (int j = 0; j < width/gridLayout.cellSize.x; j++)
            {
                //List<List<GameObject>> tileArray = new List<List<GameObject>>();
                //GameObject obj = tileArray[j][i];
                GameObject newTile;
                if (j == 0 || j == 7 || i == 0 || i == 2)
                {
                    newTile = Instantiate(wall);
                }
                else
                {
                    newTile = Instantiate(empty);
                }
                newTile.name = gameObject.name + "item at(" + i + ", " + j + ")";
                newTile.transform.SetParent(gameObject.transform);
                //Instantiate(tile, new Vector3(i * 5 - 20, j * 5 - 20, 0), transform.rotation);

            }
        }
    }
}
