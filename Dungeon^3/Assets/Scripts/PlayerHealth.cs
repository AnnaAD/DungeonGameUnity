using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public int health = 100;
	private Text healthDisplay;
	private float healthTimer;
	// Use this for initialization
	void Start () {
		healthDisplay = GetComponent<Text>();
		healthDisplay.text = "Health: " + health + "/100";
	}
	
	// Update is called once per frame
	void Update () {
		healthTimer += Time.deltaTime;
		if(healthTimer > 1) {
			if(health < 100) {
				UpdateHealth(1);
			}
			healthTimer = 0;
		}
	}

	public void UpdateHealth(int val) {
		health += val;
		healthDisplay.text = "Health: " + health + "/100";
	}
}
