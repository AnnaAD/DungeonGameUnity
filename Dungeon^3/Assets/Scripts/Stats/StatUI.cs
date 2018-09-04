using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Handles text of stats
public class StatUI : MonoBehaviour {
    // The text that lists each stat and its value
	[SerializeField] private Text statWindowText;
	private GameObject stats;
	void Start() {
		stats = GameObject.Find("Stats");
	    
		refreshStatText();
	}

	public void refreshStatText() {
		statWindowText.text = 
			"Level: "         + stats.GetComponent<PlayerStats>().level + "\n" +
			"HealthBoost: "   + stats.GetComponent<PlayerStats>().healthBoost + "\n" +
			"Speed: "         + stats.GetComponent<PlayerStats>().speed + "\n" +
			"Vitality: "      + stats.GetComponent<PlayerStats>().vitality + "\n" +
			"Swordsmanship: " + stats.GetComponent<PlayerStats>().swordsmanship + "\n" +
			"Bowmanship: "    + stats.GetComponent<PlayerStats>().bowmanship;  
	}
}
