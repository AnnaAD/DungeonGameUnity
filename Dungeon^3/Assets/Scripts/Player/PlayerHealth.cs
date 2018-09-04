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
        refreshHealthDisplay();
        health = maxHealth;
		regenRate = 1f;
        player = GameObject.Find("Player");
	}

    void OnLevelWasLoaded()
    {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
		healthTimer += Time.deltaTime;
		if(healthTimer > 1) {
			if(health < maxHealth) {
				UpdateHealth(regenRate);
			}
            if (health > maxHealth)
                health = maxHealth;
			healthTimer = 0;
		}
	}

    public void UpdateHealth(float val)
    {
        health += val;
        refreshHealthDisplay();
        if (health <= 0)
        {
            player.GetComponent<PlayerController>().killPlayer();
            healthDisplay.text = "Health: " + "0" + "/" + maxHealth;
        }
        else
        {
            refreshHealthDisplay();
        }
    }

	public void incrementMaxHealth(int amount){
		//incremented maxHealth
		maxHealth = maxHealth + amount;
        health = maxHealth;
        refreshHealthDisplay();
    }

	public void incrementRegenRate(float amount){
		regenRate = regenRate + amount;
	}

    /// <summary>
    ///  Updates the display text to match variables here
    /// </summary>
    private void refreshHealthDisplay() {
        healthDisplay.text = "Health: " + Mathf.Floor(health) + "/" + maxHealth;
    }
}
