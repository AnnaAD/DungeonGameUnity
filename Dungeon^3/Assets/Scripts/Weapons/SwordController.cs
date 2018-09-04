using UnityEngine;
using System.Collections;

public class SwordController: MonoBehaviour {
	GameObject pivotPoint;
	Inventory inventoryScript;
	PlayerStats playerStats;

	// Use this for initialization
	void Start () {
		pivotPoint = GameObject.Find("Pivot point");
		inventoryScript = GameObject.Find("Inventory").GetComponent<Inventory>();
		playerStats = GameObject.Find("Stats").GetComponent<PlayerStats>();
	}

	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter(Collision col) {
		GameObject objectHit = col.gameObject;
		if (objectHit.tag == "Enemy" && pivotPoint.GetComponent<SwordAnimation>().isSwinging) {
			Item sword = inventoryScript.GetSword();
			if (sword == null) {
				return;
			}
			float swordsmanship = playerStats.swordsmanship;
			objectHit.GetComponent<Enemy>().Damage(calculateDamage(sword.GetDamage(), swordsmanship));
		}
	}

	private float calculateDamage(float sworddamage, float swordsmanship) {
		// Do bowdamage * .7f, with an additional .05f in the multiple per 1 bowdamage increase
		return sworddamage * (.6f+(swordsmanship*.3f));
	}
}
