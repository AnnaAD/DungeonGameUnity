﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health;
	public int damage;
	public Rigidbody rBody;
	public GameObject player;
	private GameObject playerHealth;
	private GameObject playerXP;
	public int xp;
	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody> ();
		player = GameObject.Find("Player");
		playerHealth = GameObject.Find("Health");
		playerXP = GameObject.Find("XP");
		loadResources();
	}

	public void loadResources(){}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Damage(int number) {
		health -= number;
		Debug.Log(health);
		if (health <= 0) {
			GetComponent<Animator>().SetTrigger("Die");
		}
	}

	void OnCollisionStay (Collision col) {
		if (col.gameObject.name == "Player") {
			playerHealth.GetComponent<PlayerHealth>().UpdateHealth(-damage);
		}
	}

	public void Die() {
		playerXP.GetComponent<PlayerXP>().addXP(xp);
		Destroy(gameObject);
	}
}
