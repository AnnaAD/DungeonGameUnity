using UnityEngine;
using System.Collections;

public class PurpleSlime : Enemy {

	public GameObject SlimeArrow;
	public Transform bulletSpawn;
    public float timeBetweenShots = 0.5f;
	private float counter;

	public override void loadResources() {
		counter = 0;
		damage = 1;
	}

	// Update is called once per frame
	void Update () {
		counter+=Time.deltaTime;

        if (CanSeePlayer()) {
            transform.LookAt(player.transform);

            //Debug.Log(Vector3.Distance(player.transform.position,transform.position));
            if (Vector3.Distance(player.transform.position, transform.position) > 5f)
            {
                rBody.velocity = transform.forward * speed;
            }
            else if (Vector3.Distance(player.transform.position, transform.position) < 2f)
            {
                rBody.velocity = transform.forward * -speed;
            }
            else
            {
                rBody.velocity = Vector3.zero;
            }



            if (counter > timeBetweenShots)
            {
                counter = 0;
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
		bullet.GetComponent<BulletLogic> ().damage = damage;
		// Destroy the bullet after 2 seconds
		Destroy(bullet, 1.5f); 
	}


}
