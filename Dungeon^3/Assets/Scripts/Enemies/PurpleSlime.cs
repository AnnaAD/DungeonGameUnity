using UnityEngine;
using System.Collections;

public class PurpleSlime : Enemy {

	public GameObject SlimeArrow;
	public Transform bulletSpawn;
	public float timeBetweenShots;
	private float counter;

	public void loadResources() {
		counter = 0;
	}

	// Update is called once per frame
	void Update () {
		counter+=Time.deltaTime;
		transform.LookAt(player.transform);

		//Debug.Log(Vector3.Distance(player.transform.position,transform.position));
		if(Vector3.Distance(player.transform.position,transform.position) > 5f) {
			rBody.velocity = transform.forward * 3;
		} else if(Vector3.Distance(player.transform.position,transform.position) < 2f) {
			rBody.velocity = transform.forward * -3;
		} else {
			rBody.velocity = Vector3.zero;
		}



		if(counter > timeBetweenShots) {
			counter = 0;
			if(CanSeePlayer()) {
				Shoot();
			}
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
