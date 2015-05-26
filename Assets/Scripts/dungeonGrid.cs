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

        SetTile(gridObjects[40, 10], door);
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

				if (Random.value < 0.6f)
				{
					newTile = Instantiate(floor);
				}
                else if (Random.value > 0.8f)
                {
                    newTile = Instantiate(wall);
                }
				else
				{
					newTile = Instantiate(empty);
				}
                
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
}
