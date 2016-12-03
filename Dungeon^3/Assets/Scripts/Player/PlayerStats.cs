using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int healthBoost;
	public int speed;
	public int vitality;
	public int dexterity;
	public int swordsmanship;
	public int bowmanship;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
