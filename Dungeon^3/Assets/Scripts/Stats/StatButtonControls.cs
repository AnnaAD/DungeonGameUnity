using UnityEngine;
using System.Collections;

// Class responsible for handling Level Up Buttons
public class StatButtonControls : MonoBehaviour {
	private PlayerStats playerStats;
	private GameObject levelPanel;
    [SerializeField]
    private GameObject levelUpButtons;
	//How many times you leveled up but did not improve a skill
	private int statPoints = 0;

	void Start() {
		playerStats = GetComponent<PlayerStats>();
        levelUpButtons.SetActive(false);
	}


    public void leveledUp() {
        statPoints++;
        levelUpButtons.SetActive(true);
    }

    public void updateStatPoints() {
        statPoints--;
        GetComponent<StatUI>().refreshStatText();
        if (statPoints < 1)
        {
            levelUpButtons.SetActive(false);
        }
    }

	public void healthBoostClicked() {
		playerStats.updateHealthBoost(1);
        updateStatPoints();
	}

	public void speedClicked() {
		playerStats.updateSpeed(1);
        updateStatPoints();
	}

	public void vitalityClicked() {
		playerStats.updateVitality(1);
        updateStatPoints();
	}

    public void swordsmanshipClicked() {
        playerStats.updateSwordsmanship(1);
        updateStatPoints();
    }


	public void bowmanshipClicked() {
		playerStats.updateBowmanship(1);
        updateStatPoints();
	}

}
