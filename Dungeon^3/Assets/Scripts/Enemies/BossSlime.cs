using UnityEngine;
using System.Collections;

public class BossSlime : Enemy {

	private bool seen;

	[SerializeField]
	private GameObject SlimePrefab;
    private float timeSinceLastSlimes;

	// Update is called once per frame
	void Update () {

		seen = CanSeePlayer();

		if(seen) {
			Vector3 playerOnPlane =  new Vector3(player.transform.position.x, 1f, player.transform.position.z);
			transform.LookAt(playerOnPlane);
			rBody.velocity = transform.forward * speed;
			transform.position = new Vector3(transform.position.x, 1f, transform.position.z);

            if(timeSinceLastSlimes > 15) {
                Instantiate(SlimePrefab, transform.position + new Vector3(Random.Range(1f, 2.5f), 0f, Random.Range(1f, 2.5f)), Quaternion.identity);
                Instantiate(SlimePrefab, transform.position + new Vector3(Random.Range(1f, 2.5f), 0f, Random.Range(1f, 2.5f)), Quaternion.identity);
                Instantiate(SlimePrefab, transform.position + new Vector3(Random.Range(1f, 2.5f), 0f, Random.Range(1f, 2.5f)), Quaternion.identity);
                timeSinceLastSlimes = 0;
            }


        } else {
			
				//idle mode
				//Debug.Log("idle: " + name);
				rBody.velocity = transform.forward * 1;
				transform.Rotate(new Vector3(0,(Random.value * 2)-1,0));

				/* if(Physics.Raycast(transform.position, transform.forward, 3f)) {
					transform.Rotate(new Vector3(0,15,0));
					Debug.Log("turning?");
				} */

		}
		//Debug.Log(lastSeen);
		//Debug.Log(checkedLastSeen);
        timeSinceLastSlimes += Time.deltaTime;
	}

	void OnCollsionEnter(Collision col) {
		Debug.Log("turn");
		if(col.gameObject.tag != "Player") {
			transform.Rotate(new Vector3(0,90,0));
			rBody.AddForce(transform.forward * 5);
		}
	}

	new void Die() {
		Debug.Log("Die");
		for(int i = 0; i < 20; i++) {
			GameObject slime = Instantiate(SlimePrefab) as GameObject;
			slime.transform.position = transform.position;
		}

		base.Die();
	}
}