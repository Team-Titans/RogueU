using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MovementProto healthDisp = GameObject.FindObjectOfType<MovementProto>();
		if (healthDisp != null)
		{
			healthDisp.OnHealthChanged += UpdateHealthDisplay;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateHealthDisplay(int health)
	{
		Text temp = gameObject.GetComponent<Text>();
		if (temp != null)
		{
			temp.text = "HP: " + health.ToString() + "//20";
		}
	}
}
