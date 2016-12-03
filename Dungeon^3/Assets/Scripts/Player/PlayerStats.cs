using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int healthBoost;
	public int speed;
	public int vitality;
	public int dexterity;
	public int swordsmanship;
	public int bowmanship;

	//TODO: Assign statistics (i.e. speed, strength, etc. and have them incremented when character levels up)
	public void LevelUp(){

	}

	public void updateHealthBoost(int val) {
		healthBoost+= val;
	}

	public void updateSpeed(int val) {
		speed += val;
	}

	public void updateVitality(int val) {
		vitality += val;
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
