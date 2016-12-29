﻿using UnityEngine;
using System.Collections;

public class ArrowBehavior : MonoBehaviour {
	Rigidbody rigidbody;
	GameObject player;
		// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		rigidbody = GetComponent<Rigidbody>();
		Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>(),true);
	}
		
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter (Collision col) {
		rigidbody.constraints = RigidbodyConstraints.None;
		if(col.gameObject.tag == "Enemy") {
			float bowmanship = player.GetComponent<PlayerStats> ().bowmanship;
			Item bow = GameObject.Find ("Player").GetComponent<Inventory> ().GetBow();
			if (bow == null) {
				return;
			}
			Debug.Log("Damage. Bowmanship: "+bowmanship+" Bow Item Damage:"+bow.GetDamage());
			col.gameObject.GetComponent<Enemy>().Damage((bow.GetDamage()*(.7f+(bowmanship*.05f)))); 
		}
	}
}