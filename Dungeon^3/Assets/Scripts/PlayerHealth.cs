using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public int health = 100;
	private Text healthDisplay;
	// Use this for initialization
	void Start () {
		healthDisplay = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		healthDisplay.text = "Health: " + health + "/100";
	}

	public void UpdateHealth(int val) {
		health += val;
	}
}
