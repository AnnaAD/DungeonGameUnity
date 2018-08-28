using UnityEngine.UI;
using System.Collections;
using UnityEngine;
public class PlayerXP : MonoBehaviour {
	public int level;
	private Text xpDisplay;
	public int maxXP;
	private int xp;
	public float xpFactor;
	public PlayerStats playerStats;

	// Use this for initialization
	void Start () {
		playerStats = GameObject.Find("Stats").GetComponent<PlayerStats>();
		xp = 0;
		xpDisplay = GetComponent<Text> ();
		xpDisplay.text = "XP: " + xp + "/" + maxXP;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void addXP(int xpGain) {
		if (xpGain + xp < maxXP) {
			xp += xpGain;
		} else {
			playerStats.LevelUp();
			xp = xp+xpGain - maxXP;
			maxXP = Mathf.RoundToInt(maxXP * xpFactor);
			xpFactor++;
			addXP(0);
		}
		xpDisplay.text = "XP: " + xp + "/" + maxXP;	
	}

}
