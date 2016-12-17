using UnityEngine;
using System.Collections;

public class StatButtonControls : MonoBehaviour {
	[SerializeField]
	private GameObject player;
	private GameObject levelPanel;
	private GameObject statDisplay;

	void Start() {
		player = GameObject.Find("Player");
		statDisplay = GameObject.Find("StatText");
	}

	public void healthBoostClicked() {
		player.GetComponent<PlayerStats>().updateHealthBoost(1);
		gameObject.SetActive(false);
		statDisplay.GetComponent<StatUI>().updateStats();
	}

	public void speedClicked() {
		player.GetComponent<PlayerStats>().updateSpeed(1);
		gameObject.SetActive(false);
		statDisplay.GetComponent<StatUI>().updateStats();
	}

	public void vitalityClicked() {
		player.GetComponent<PlayerStats>().updateVitality(1);
		gameObject.SetActive(false);
		statDisplay.GetComponent<StatUI>().updateStats();
	}

	public void dexterityClicked() {
		player.GetComponent<PlayerStats>().updateDexterity(1);
		gameObject.SetActive(false);
		statDisplay.GetComponent<StatUI>().updateStats();
	}

	public void swordsmanshipClicked() {
		player.GetComponent<PlayerStats>().updateSwordsmanship(1);
		gameObject.SetActive(false);		
		statDisplay.GetComponent<StatUI>().updateStats();
	}

	public void bowmanshipClicked() {
		player.GetComponent<PlayerStats>().updateBowmanship(1);
		gameObject.SetActive(false);
		statDisplay.GetComponent<StatUI>().updateStats();
	}
}
