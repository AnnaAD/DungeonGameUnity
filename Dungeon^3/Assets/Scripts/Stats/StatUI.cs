using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatUI : MonoBehaviour {
	private Text displayStats;
	private GameObject player;

	void Start() {
		player = GameObject.Find("Stats");
		displayStats = GetComponent<Text>();
		updateStats();
	}

	public void updateStats() {
		displayStats.text = 
			"Level: "         + player.GetComponent<PlayerStats>().level + "\n" +
			"HealthBoost: "   + player.GetComponent<PlayerStats>().healthBoost + "\n" +
			"Speed: "         + player.GetComponent<PlayerStats>().speed + "\n" +
			"Vitality: "      + player.GetComponent<PlayerStats>().vitality + "\n" +
			"Dexterity: "	  + player.GetComponent<PlayerStats>().dexterity + "\n" +
			"Swordsmanship: " + player.GetComponent<PlayerStats>().swordsmanship + "\n" +
			"Bowmanship: "    + player.GetComponent<PlayerStats>().bowmanship;  
	}
}
