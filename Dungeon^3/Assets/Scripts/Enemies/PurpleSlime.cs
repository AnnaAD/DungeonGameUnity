using UnityEngine;
using System.Collections;

public class PurpleSlime : Enemy {

	public GameObject SlimeArrow;
	public Transform bulletSpawn;

	private int counter;

	public void loadResources() {
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		transform.LookAt(player.transform);

		//Debug.Log(Vector3.Distance(player.transform.position,transform.position));
		if(Vector3.Distance(player.transform.position,transform.position) > 3f) {
			rBody.velocity = transform.forward * 3;
		} else {
			rBody.velocity = Vector3.zero;
		}

		if(counter > 10) {
			counter = 0;
			Shoot();
		}


		transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

	}

	public void Shoot() {
		GameObject bullet = Instantiate(
			SlimeArrow,
			bulletSpawn.position,
			bulletSpawn.rotation) as GameObject;

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 7f;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 1.5f); 
	}
}
