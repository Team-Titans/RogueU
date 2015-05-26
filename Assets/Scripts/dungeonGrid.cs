using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class dungeonGrid : MonoBehaviour {

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
    public GameObject [,] gridObjects = new GameObject [80,20];

	// Use this for initialization
	void Start ()
    {
        AddImages();

        //for debugging purposes
        //foreach (RectTransform child in gameObject.GetComponentsInChildren<RectTransform>())
        //{
        //    Debug.Log(child.position.x + child.name);
        //}

        CreateRoom3(40,10);
        CreateRoom3((int)Random.Range(3.0f, 77.0f), (int)Random.Range(3.0f, 18.0f));

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

                // make a gameObject with sprite empty
				newTile = Instantiate(empty);
                
                // set obj name 
                newTile.name = gameObject.name + "item at(" + j + ", " + i + ")";
                // sets the panel(gameObject) as the parent of the newTile
                newTile.transform.SetParent(gameObject.transform);

                // store data in 2D array
                gridObjects[j, i] = newTile;
            }
        }
    }

    class Tile
    {
        public int x, y, id;
    };

    void changeImages(List<Tile> tList)
    {
        // get all list
        foreach(Tile t in tList)
        {
            gridObjects[t.x, t.y] = objectID[t.id];
        }
    }

    //Takes a GameObject A and sets its Sprite to the sprite of GameObject B
    //
    void SetTile(GameObject a_Tile, GameObject a_Prefab)
    {
        Sprite prefabSprite = a_Prefab.GetComponent<Image>().sprite;

        Image tileSprite = a_Tile.GetComponent<Image>();
        tileSprite.sprite = prefabSprite;
    }

    //Create 3x3 room using center origin
    void CreateRoom3(int x, int y)
    {

        SetTile(gridObjects[x, y], floor);

        //Right
        if (x < 78)
        {
            SetTile(gridObjects[x + 1, y], floor);
            SetTile(gridObjects[x + 2, y], wall);
        }
        //Left
        if (x > 1)
        {
            SetTile(gridObjects[x - 1, y], floor);
            SetTile(gridObjects[x - 2, y], wall);
        }

        //Up
        if (y < 18)
        {
            SetTile(gridObjects[x, y + 1], floor);
            SetTile(gridObjects[x, y + 2], wall);
        }

        //Down
        if (y > 1)
        {
            SetTile(gridObjects[x, y - 1], floor);
            SetTile(gridObjects[x, y - 2], wall);

        }

        //Top-Right
        if (x < 78 && y < 18)
        {
            SetTile(gridObjects[x + 1, y + 1], floor);
            SetTile(gridObjects[x + 2, y + 1], wall);

            SetTile(gridObjects[x + 1, y + 2], wall);
            SetTile(gridObjects[x + 2, y + 2], wall);
        }
        
        //Top-Left
        if (x > 1 && y < 18)
        {
            SetTile(gridObjects[x - 1, y + 1], floor);
            SetTile(gridObjects[x - 2, y + 1], wall);

            SetTile(gridObjects[x - 1, y + 2], wall);
            SetTile(gridObjects[x - 2, y + 2], wall);
        }

        //Bottom-Left
        if (x > 1 && y > 1)
        {
            SetTile(gridObjects[x - 1, y - 1], floor);
            SetTile(gridObjects[x - 2, y - 1], wall);

            SetTile(gridObjects[x - 1, y - 2], wall);
            SetTile(gridObjects[x - 2, y - 2], wall);
        }

        //Bottom-Right
        if (x < 78 && y > 1)
        {
            SetTile(gridObjects[x + 1, y - 1], floor);
            SetTile(gridObjects[x + 2, y - 1], wall);

            SetTile(gridObjects[x + 1, y - 2], wall);
            SetTile(gridObjects[x + 2, y - 2], wall);
        }
    }
}
