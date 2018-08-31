using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public float health;
	private Text healthDisplay;
	private float healthTimer;
    // Updated from console
	public int maxHealth;
	public float regenRate;
    private GameObject player;
	// Use this for initialization
	void Start () {
		healthDisplay = GetComponent<Text>();
		healthDisplay.text = "Health: " + Mathf.Floor(health) + "/"+maxHealth;
		
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

    public void UpdateHealth(float val)
    {
        health += val;
        healthDisplay.text = "Health: " + Mathf.Floor(health) + "/" + maxHealth;
        if (health <= 0)
        {
            player.GetComponent<PlayerController>().killPlayer();
            healthDisplay.text = "Health: " + "0" + "/" + maxHealth;
        }
        else
        {
            healthDisplay.text = "Health: " + Mathf.Floor(health) + "/" + maxHealth;

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
