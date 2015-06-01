using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class panelGrid : MonoBehaviour {

    // GameObjects that are stored as prefabs from unity
    public GameObject empty;    // 0
    public GameObject wall;     // 1
    public GameObject floor;    // 2
    public GameObject door;     // 3
    public GameObject stairs;   // 4
    public GameObject path;     // 5

    // create a dictionary to match numbers with gameobjects
    public Dictionary<int, GameObject> objectID = new Dictionary<int, GameObject>(); 

    // create 2D array to store grid tiles gGameObjects
    public GameObject [,] gridObjects = new GameObject [20,80];

	// Use this for initialization
	void Start ()
    {
        AddImages();
        CreateDictionary();

        //for debugging purposes
        foreach (RectTransform child in gameObject.GetComponentsInChildren<RectTransform>())
        {
            Debug.Log(child.position.x + child.name);
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    void AddImages()
    {
        // get panels width and height
        RectTransform rec = gameObject.GetComponent<RectTransform>();
        float height = rec.rect.height;
        float width =  rec.rect.width;

        // get the cellsize of the grid
        GridLayoutGroup gridLayout = gameObject.GetComponent<GridLayoutGroup>();
        float xPos = gridLayout.cellSize.x;
        float yPos = gridLayout.cellSize.y;

        for (int i = 0; i < height/ yPos; i++)
        {
            for (int j = 0; j < width/ xPos; j++)
            {
                GameObject newTile;
                if (j == 0 || j == 7 || i == 0 || i == 2)
                {
                    // make a gameObject with sprite wall
                    newTile = Instantiate(path);
                }
                else
                {
                    // make a gameObject with sprite empty
                    newTile = Instantiate(empty);
                }

                // set obj name 
                newTile.name = gameObject.name + "item at(" + j + ", " + i + ")";
                // sets the panel(gameObject) as the parent of the newTile
                newTile.transform.SetParent(gameObject.transform);

                // store data in 2D array
                gridObjects[i, j] = newTile;
            }
        }
    }

    void CreateDictionary()
    {
        objectID.Add(0, empty);
        objectID.Add(1, wall);
        objectID.Add(2, floor);
        objectID.Add(3, door);
        objectID.Add(4, stairs);
        objectID.Add(5, path);
    }

    class Tile
    {
        public int x = 0, y = 0, id = 0;
    };

    void changeImages(List<Tile> tList)
    {
        // get all list
        foreach(Tile t in tList)
        {
            gridObjects[t.x, t.y] = objectID[t.id];
        }
    }
}
