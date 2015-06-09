using UnityEngine;
using System.Collections;

public class lighting : MonoBehaviour
{

    public GameObject CarbonToFollow;
    public Light DirLight;
    Transform trans;

    // Use this for initialization
    void Start()
    {
        trans = CarbonToFollow.transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        DirLight.transform.position = new Vector3(trans.position.x, trans.position.y, -15);
        //Debug.Log(CarbonToFollow.transform.position.x + "," + CarbonToFollow.transform.position.y);
    }
}
