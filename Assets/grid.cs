using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class grid : MonoBehaviour
{
    public enum TileType
    {
        WALL, FLOOR, DOOR, STAIRS, EMPTY, PATH

    };

    private int width = 10;
    private int height = 10;
    public GameObject b;

    // Use this for initialization
    void Start()
    {
        //test();
    }

    void test()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Instantiate(b, new Vector3(i * 5 - 20, j * 5 - 20, 0), transform.rotation);
            }
        }

        //Instantiate(b, transform.position, transform.rotation);
        //Instantiate(b, transform.position, transform.rotation);
    }

    void InitGrid()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                //Tile temp = new Tile();
                //gridList.Add(temp);
                //Instantiate(, new Vector3(i * 5 - 20, j * 5 - 20, 0), transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
