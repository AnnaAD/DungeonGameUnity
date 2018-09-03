using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatUI : MonoBehaviour {
	private Text displayStats;
	private GameObject stats;

	void Start() {
		stats = GameObject.Find("Stats");
		displayStats = GetComponent<Text>();
		updateStats();
	}

	public void updateStats() {
		displayStats.text = 
			"Level: "         + stats.GetComponent<PlayerStats>().level + "\n" +
			"HealthBoost: "   + stats.GetComponent<PlayerStats>().healthBoost + "\n" +
			"Speed: "         + stats.GetComponent<PlayerStats>().speed + "\n" +
			"Vitality: "      + stats.GetComponent<PlayerStats>().vitality + "\n" +
			"Dexterity: "	  + stats.GetComponent<PlayerStats>().dexterity + "\n" +
			"Swordsmanship: " + stats.GetComponent<PlayerStats>().swordsmanship + "\n" +
			"Bowmanship: "    + stats.GetComponent<PlayerStats>().bowmanship;  
	}
}
