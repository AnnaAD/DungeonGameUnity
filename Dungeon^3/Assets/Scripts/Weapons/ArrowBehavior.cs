using UnityEngine;
using System.Collections;

public class ArrowBehavior : MonoBehaviour {
	Rigidbody rigidbody;
	GameObject player;
	// Script that contains variables for all player's stats
	PlayerStats playerStats;
	// Script that contains inventory information
	Inventory inventoryScript;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		playerStats = GameObject.Find("Stats").GetComponent<PlayerStats>();
		inventoryScript = GameObject.Find("Inventory").GetComponent<Inventory>();
		rigidbody = GetComponent<Rigidbody>();
		Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>(),true);
	}
		
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter (Collision col) {
		rigidbody.constraints = RigidbodyConstraints.None;
		if(col.gameObject.tag == "Enemy") {
			float bowmanship = playerStats.bowmanship;
			Item bow = inventoryScript.GetBow();
			if (bow == null) {
				return;
			}
			// Debug.Log("Damage. Bowmanship: "+bowmanship+" Bow Item Damage:"+bow.GetDamage());
			col.gameObject.GetComponent<Enemy>().Damage(calculateDamage(bow.GetDamage(), bowmanship)); 
		}
	}

	private float calculateDamage(float bowdamage, float bowmanship) {
		// Do bowdamage * .7f, with an additional .05f in the multiple per 1 bowdamage increase
		return bowdamage * (1f+(bowmanship*.5f));
	}
}