using UnityEngine;
using System.Collections;

// Class responsible for handling Level Up Buttons
public class StatButtonControls : MonoBehaviour {
	[SerializeField]
	private PlayerStats playerStats;
	private GameObject levelPanel;
	private GameObject statDisplay;

	//How many times you leveled Up
	public int levelsUp = 0;

	void Start() {
		playerStats = GameObject.Find("Stats").GetComponent<PlayerStats>();
		statDisplay = GameObject.Find("StatText");
	}

	public void healthBoostClicked() {
		playerStats.updateHealthBoost(1);
		levelsUp--;
		if (levelsUp < 1) {
			gameObject.SetActive(false);
			statDisplay.GetComponent<StatUI>().updateStats();
		}
	}

	public void speedClicked() {
		playerStats.updateSpeed(1);
		levelsUp--;
		if (levelsUp < 1) {
			gameObject.SetActive(false);
			statDisplay.GetComponent<StatUI>().updateStats();
		}
	}

	public void vitalityClicked() {
		playerStats.updateVitality(1);
		levelsUp--;
		if (levelsUp < 1) {
			gameObject.SetActive(false);
			statDisplay.GetComponent<StatUI>().updateStats();
		}
	}

	/*public void dexterityClicked() {
		playerStats.updateDexterity(1);
		levelsUp--;
		if (levelsUp < 1) {
			gameObject.SetActive(false);
			statDisplay.GetComponent<StatUI>().updateStats();
		}
	}*/

	public void swordsmanshipClicked() {
		playerStats.updateSwordsmanship(1);
		levelsUp--;
		if (levelsUp < 1) {
			gameObject.SetActive(false);		
			statDisplay.GetComponent<StatUI>().updateStats();
		}
	}

	public void bowmanshipClicked() {
		playerStats.updateBowmanship(1);
		levelsUp--;
		if (levelsUp < 1) {
			gameObject.SetActive(false);
			statDisplay.GetComponent<StatUI>().updateStats();
		}
	}

	public void leveledUp() {
		levelsUp++;
	}
}
