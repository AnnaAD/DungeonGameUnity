using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public float health = 100f;
	private Text healthDisplay;
	private float healthTimer;
	public int maxHealth;
	public float regenRate;
	// Use this for initialization
	void Start () {
		healthDisplay = GetComponent<Text>();
		healthDisplay.text = "Health: " + Mathf.Floor(health) + "/"+maxHealth;
		maxHealth = 100;
		regenRate = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		healthTimer += Time.deltaTime;
		if(healthTimer > 1) {
			if(health < maxHealth) {
				UpdateHealth(regenRate);
			}
			healthTimer = 0;
		}
	}

	public void UpdateHealth(float val) {
		health += val;
		healthDisplay.text = "Health: " + Mathf.Floor(health) + "/"+maxHealth;
	}

	public void incrementMaxHealth(int amount){
		//incremented maxHealth
		maxHealth = maxHealth + amount;
		UpdateHealth (maxHealth - health);
	}
	public void incrementRegenRate(float amount){
		regenRate = regenRate + amount;
	}
}
