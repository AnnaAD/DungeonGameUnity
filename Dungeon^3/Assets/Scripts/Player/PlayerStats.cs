using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int level;
	public int healthBoost;
	public int speed;
	public int vitality;
	public int dexterity;
	public int swordsmanship;
	public int bowmanship;
	public GameObject StatDisplay;
	public GameObject LevelUpDisplay;
	public PlayerHealth healthScript;
	public PlayerController playerScript;
	//TODO: Assign statistics (i.e. speed, strength, etc. and have them incremented when character levels up)
	public void Start(){
		healthScript = GameObject.Find ("Health").GetComponent<PlayerHealth> ();
		playerScript = GameObject.Find ("Player").GetComponent<PlayerController>();
	}

	public void LevelUp(){
		Debug.Log("leveled up");
		level++;
		StatDisplay.GetComponent<StatUI>().updateStats();
		LevelUpDisplay.GetComponent<StatButtonControls>().leveledUp();
		LevelUpDisplay.SetActive(true);
	}

	public void updateHealthBoost(int val) {
		healthBoost+= val;
		healthScript.incrementMaxHealth (val*25);
	}

	public void updateSpeed(int val) {
		speed += val;
		playerScript.incrementSpeed (val * .2f);
	}

	public void updateVitality(int val) {
		vitality += val;
		healthScript.incrementRegenRate (.2f*val);	
	}

	public void updateDexterity(int val) {
		dexterity += val;
	}

	public void updateSwordsmanship(int val) {
		swordsmanship += val;
	}

	public void updateBowmanship(int val) {
		bowmanship += val;
	}
}
