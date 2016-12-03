using UnityEngine;
using System.Collections;

public class GreenSlime : Enemy {
	private Vector3 lastSeen;
	private bool seen;
	private bool checkedLastSeen;
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Debug.DrawRay(transform.position, transform.forward);
		seen = CanSeePlayer();

		if(seen) {
			transform.LookAt(player.transform);
			rBody.velocity = transform.forward * 3;
			transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
			lastSeen = player.transform.position;
			checkedLastSeen = false;
		
		} else {
			//TODO: Fix this as it never actually gets to the lastSeen point
			if(Vector3.Distance(transform.position,lastSeen) < 5f) {
				checkedLastSeen = true;
			}

			//Debug.Log("distance to last seen: " + Vector3.Distance(transform.position,lastSeen));

			if(checkedLastSeen == false) {
				transform.LookAt(lastSeen);
				rBody.velocity = transform.forward * 3;
				transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
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


		}
		//Debug.Log(lastSeen);
		//Debug.Log(checkedLastSeen);
	}

	private bool CanSeePlayer(){

		RaycastHit hit;
		if(Physics.Linecast(transform.position, player.transform.position, out hit)) {
			if(hit.collider.gameObject.name == "Player") {
				return true;
			} else {
				return false;
			}
		}

		Debug.Log("This shouldn't happen...");
		return false;
	}

	void OnCollsionEnter(Collision col) {
		Debug.Log("turn");
		if(!checkedLastSeen) {
			transform.Rotate(new Vector3(0,90,0));
			rBody.AddForce(transform.forward * 5);
		}
	}
}