using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public float health = 100f;
	private Text healthDisplay;
	private float healthTimer;
	public int maxHealth;
	public float regenRate;
    private GameObject player;
	// Use this for initialization
	void Start () {
		healthDisplay = GetComponent<Text>();
		healthDisplay.text = "Health: " + Mathf.Floor(health) + "/"+maxHealth;
		maxHealth = 1;
        health = maxHealth;
		regenRate = 1f;
		UpdateHealth(0);
        player = GameObject.Find("Player");
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
        if(health <= 0)
        {
            Debug.Log("PlayerHealth registers death");
            player.GetComponent<PlayerController>().killPlayer();
        }
	}

	public void incrementMaxHealth(int amount){
		//incremented maxHealth
		maxHealth = maxHealth + amount;
        health = maxHealth;
	}
	public void incrementRegenRate(float amount){
		regenRate = regenRate + amount;
	}
}
